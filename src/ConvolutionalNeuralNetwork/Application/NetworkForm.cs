using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recognition.Image;
using Recognition.NeuralNet;
using Recognition.Utils;

namespace Recognition.Application
{
    public partial class NetworkForm : Form
    {
        private Network _network = new Network();
        private CancellationToken _cancelTrainToken;
        private ActionRepeater _statRefresher;
        private readonly TaskScheduler _uiScheduler;
        private readonly TaskFactory _taskFactory;
        private string _history;

        private string History
        {
            get { return _history; }
            set { SetActualHistory(_history = value); }
        }

        private void SetActualHistory(string value)
        {
            _taskFactory.StartNew(() => txtStatistics.Text = value);
        }

        public NetworkForm()
        {
            InitializeComponent();
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _taskFactory = new TaskFactory(_uiScheduler);
        }

        #region Распознание

        public void RecognizeImage(NormalizedImage image)
        {
            Debug.Assert(image != null);

            image.PadCanvas(Network.InputImageWidth, Network.InputImageHeight);

            var output = _network.Calculate(image.RawData);

            RefreshNetworkImage();
            
            var builder = new StringBuilder();
            var maxValueIndex = 0;
            for (var i = 0; i < output.Length; i++)
            {
                builder.AppendFormat("{0}: {1:0.00}", i, output[i]).AppendLine();
                if (output[i] > output[maxValueIndex]) maxValueIndex = i;
            }
            builder.AppendFormat("Ответ сети: {0}", maxValueIndex).AppendLine();
            History = builder + History;
        }

        private void RefreshNetworkImage()
        {
            var graphics = imgLayersOutputs.CreateGraphics();

            graphics.Clear(Color.White);
            for (int i = 0, x = 10; i < _network.Layers.Length; i++)
            {
                var layerImage = _network.Layers[i].ToNormalizedImage().ToBitmap().Resize(4, InterpolationMode.NearestNeighbor);
                graphics.DrawImageUnscaled(layerImage, x, 10);
                x += 10 + layerImage.Width;
            }
            graphics.Save();
        }

        #endregion

        #region Обучение

        [Obsolete("Нормализованные изображения")]
        public void TrainNetwork(MNistImage[] images, CancellationToken cancellation)
        {
            Debug.AssertNotNull(images);
            Debug.Assert(cancellation != null);
            if (_statRefresher != null && _statRefresher.Started) return;

            _cancelTrainToken = cancellation;

            var normalImages = new NormalizedImage[images.Length];
            for (var i = 0; i < images.Length; i++)
                normalImages[i] = new NormalizedImage(images[i]);

            _statRefresher = new ActionRepeater(PrintTrainingInfo, 1000.0);
            _statRefresher.Start(false);

            TrainProcess(normalImages);

            _statRefresher.Stop(true);
            History = txtStatistics.Text;
        }

        private void TrainProcess(NormalizedImage[] images)
        {
            while (!_cancelTrainToken.IsCancellationRequested)
            {
                ArrayHelper<NormalizedImage>.Shuffle(images);

                for (var i = 0; i < images.Length && !_cancelTrainToken.IsCancellationRequested; i++)
                {
                    var image = images[i]; //TODO foreach
                    image.PadCanvas(Network.InputImageWidth, Network.InputImageHeight);

                    var desiredOutput = ArrayHelper<double>.CreateScalar(10, -1.0, images[i].Label.Value, 1.0);
                    _network.Train(image.RawData, desiredOutput);
                }
            }
        }

        private void PrintTrainingInfo()
        {
            var state = _network.TrainingInfo;

            var builder = new StringBuilder();
            builder.AppendFormat("Ошибка (последние 200 образцов): {0:0.00}\r\n", state.AverageMSE);
            builder.AppendFormat("Образцов всего: {0}\r\n", state.BackPropagationsCount);
            builder.AppendFormat("Эпох пройдено: {0}\r\n", state.EpochsCount);
            builder.AppendFormat("Коэффициент обучения {0}\r\n", state.CurrentLearningRate);

            SetActualHistory(builder + History);
        }

        #endregion

        #region Тестирование

        private readonly StringBuilder _testInfoBuffer = new StringBuilder();
        private readonly ConcurrentStack<int> _errors = new ConcurrentStack<int>(); 
        private int _imageProcessed;
        private double _totalMSE;

        public void TestNetwork(MNistImage[] images, CancellationToken cancellation)
        {
            Debug.AssertNotNull(images);
            Debug.AssertNotNull(cancellation);

            if (_statRefresher != null && _statRefresher.Started) return;

            _cancelTrainToken = cancellation;

            var normalImages = new NormalizedImage[images.Length];
            for (var i = 0; i < images.Length; i++)
            {
                normalImages[i] = new NormalizedImage(images[i]);
                normalImages[i].PadCanvas(Network.InputImageWidth, Network.InputImageHeight);
            }

            _testInfoBuffer.Clear();
            _imageProcessed = 0;
            _errors.Clear();
            _totalMSE = 0.0;
            
            _statRefresher = new ActionRepeater(PrintTestingInfo, 1000.0);
            _statRefresher.Start(false);

            TestProcess(normalImages);

            _statRefresher.Stop(true);
            History = txtStatistics.Text;
        }

        private void TestProcess(NormalizedImage[] images)
        {
            for (_imageProcessed = 0; _imageProcessed < images.Length; _imageProcessed++)
            {
                var desiredOutput = ArrayHelper<double>.CreateScalar(10, -1.0, images[_imageProcessed].Label.Value, 1.0);
                var output = _network.Calculate(images[_imageProcessed].RawData);

                var answer = ArrayMath.MaxValueIndex(output);
                var mse = ArrayMath.CalculateMSE(output, desiredOutput);

                if (answer != images[_imageProcessed].Label) _errors.Push(_imageProcessed);
                _totalMSE += mse;

                if (_cancelTrainToken.IsCancellationRequested) break;
            }
        }

        private void PrintTestingInfo()
        {
            var builder = new StringBuilder();
            builder.AppendFormat("Пройдено образцов: {0}\r\n", _imageProcessed);
            builder.AppendFormat("Ошибок: {0}\r\n", _errors.Count);
            builder.AppendFormat("Суммарная ошибка: {0:0.00}\r\n", _totalMSE/_imageProcessed);
            builder.AppendFormat("Неправильно опознанные: {0}\r\n", string.Join(", ", _errors));

            SetActualHistory(builder + History);
        }

        #endregion

        #region События

        private void MenuNetworkCreateClick(object sender, EventArgs e)
        {
            _network = new Network();

            Text = "Нейронная сеть - Новая";
        }

        private void MenuNetworkSaveAsClick(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog {Title = "Сохранение сети", Filter = "Файл сети|*.cnn"};
            if (dialog.ShowDialog() != DialogResult.OK) return;
            var networkPath = dialog.FileName;

            CNNFileManager.SaveNetwork(_network, networkPath);
            Text = "Нейронная сеть - " + dialog.FileName;
        }

        private void MenuNetworkOpenClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog {Title = "Выберите файл нейронной сети", Filter = "Файл сети|*.cnn"};
            if (dialog.ShowDialog() != DialogResult.OK) return;
            var networkPath = dialog.FileName;

            _network = CNNFileManager.GetNetwork(networkPath);
            Text = "Нейронная сеть - " + dialog.FileName;
        }

        private void BtnClearHistoryClick(object sender, EventArgs e)
        {
            History = string.Empty;
            txtStatistics.Text = string.Empty;
        }

        #endregion

    }
}
