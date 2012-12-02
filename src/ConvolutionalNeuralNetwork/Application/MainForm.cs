using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recognition.Image;

namespace Recognition.Application
{
    public partial class MainForm : Form
    {
        private MNistImage[] nistImages;
        //private MNistImage currentMNistImage;
        private NormalizedImage currentInputImage;
        private readonly NetworkForm _networkForm = new NetworkForm();
        private CancellationTokenSource _tokenSource;

        public MainForm()
        {
            InitializeComponent();
            _networkForm.Show();
            DisablePanels(PanelsState.TrainingDisabled | PanelsState.TestingDisabled | PanelsState.RecognizingDisabled);
        }

        private void BtnOpenMNistClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Выберите файл изображений";
            dialog.Filter = "Файл изображений|*.idx3-ubyte";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            var imagesPath = dialog.FileName;

            dialog.Reset();
            dialog.Title = "Выберите файл подписей";
            dialog.Filter = "Файл подписей|*.idx1-ubyte";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            var labelsPath = dialog.FileName;

            nistImages = MNistFileManager.GetImageSet(labelsPath, imagesPath);

            udMNistImageIndex.Maximum = nistImages.Length - 1;
            lblMNistInfo.Text = string.Format("{0} элементов", nistImages.Length);
            lblMNistInfo.ForeColor = Color.DarkGreen;

            UdMNistImageIndexValueChanged(udMNistImageIndex, EventArgs.Empty);
            DisablePanels(PanelsState.AllEnabled);
        }

        private async void BtnStartTrainingClick(object sender, EventArgs e)
        {
            if (nistImages != null)
            {
                DisablePanels(PanelsState.TrainingNow);
                _tokenSource = new CancellationTokenSource();
                await Task.Factory.StartNew(() => _networkForm.TrainNetwork(nistImages, _tokenSource.Token));
                DisablePanels(PanelsState.AllEnabled);
            }
        }

        private void BtnStopTrainingClick(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
        }

        private async void BtnStartTestingClick(object sender, EventArgs e)
        {
            if (nistImages != null)
            {
                DisablePanels(PanelsState.TestingNow);
                _tokenSource = new CancellationTokenSource();
                await Task.Factory.StartNew(() => _networkForm.TestNetwork(nistImages, _tokenSource.Token));
                DisablePanels(PanelsState.AllEnabled);
            }
        }

        private void BtnStopTestingClick(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
        }

        private void UdMNistImageIndexValueChanged(object sender, EventArgs e)
        {
            var index = (int) udMNistImageIndex.Value;
            if (nistImages != null)
            {
                if (0 <= index && index < nistImages.Length)
                {
                    imgMNistImage.Image = nistImages[index].ToBitmap().Resize(2, InterpolationMode.NearestNeighbor);
                    lblMNistImage.Text = "Подпись базы: " + nistImages[index].Label;

                    currentInputImage = new NormalizedImage(nistImages[index]);
                }
            }
            else
            {
                MessageBox.Show("База MNist не загружена", "Изображение не получено",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRecognizeImageClick(object sender, EventArgs e)
        {
            if (currentInputImage != null)
            {
                _networkForm.RecognizeImage(currentInputImage);
            }
        }


        private void BtnOpenImageClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog {Title = "Выберите файл изображения", Filter = "Файл изображения|*.jpg"};
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var bitmap = (new Bitmap(dialog.FileName)).Resize(new Size(28, 28), InterpolationMode.High);
                currentInputImage = new NormalizedImage(bitmap);

                imgMNistImage.Image = currentInputImage.ToBitmap().Resize(2, InterpolationMode.NearestNeighbor);
                lblImageInfo.Text = string.Format("Загружено: {0}", dialog.SafeFileName);
                lblImageInfo.ForeColor = Color.DarkGreen;
                DisablePanels(PanelsState.AllEnabled);
            }
            catch
            {
                
            }
        }

        private void DisablePanels(PanelsState panelsState)
        {
            // включение всего
            btnOpenMNist.Enabled = true;
            btnStartTraining.Enabled = btnStopTraining.Enabled = true;
            btnStartTesting.Enabled = btnStopTesting.Enabled = true;
            btnRecognizeImage.Enabled = true;
            
            var panelsStateValues = Enum.GetValues(typeof (PanelsState));
            foreach (PanelsState stateValue in panelsStateValues)
            {
                if (panelsState.HasFlag(stateValue))
                {
                    switch (stateValue)
                    {
                        case PanelsState.OpeningDisabled:
                            btnOpenMNist.Enabled = false;
                            btnOpenImage.Enabled = false;
                            break;
                        case PanelsState.StartTrainingDisabled:
                            btnStartTraining.Enabled = false;
                            break;
                        case PanelsState.StopTrainingDisabled:
                            btnStopTraining.Enabled = false;
                            break;
                        case PanelsState.StartTestingDisabled:
                            btnStartTesting.Enabled = false;
                            break;
                        case PanelsState.StopTestingDisabled:
                            btnStopTesting.Enabled = false;
                            break;
                        case PanelsState.RecognizingDisabled:
                            btnRecognizeImage.Enabled = false;
                            break;
                    }
                }
            }
        }
    }
}
