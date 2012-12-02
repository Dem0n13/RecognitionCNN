using Recognition.Utils;

namespace Recognition.NeuralNet
{
    public sealed class Network
    {
        #region Константы

        public const int InputImageWidth = 29;
        public const int InputImageHeight = 29;

        public const int KernelWidth = 5;
        public const int KernelHeight = 5;
        public const int KernelStep = 2;

        public const int L1MapsCount = 6;
        public const int L2MapsCount = 50;
        public const int L3NeuronsCount = 100;
        public const int L4NeuronsCount = 10;

        #endregion

        #region Расчеты для слоев

        /// <summary>
        /// Длина вектора ядра.
        /// </summary>
        public const int KernelLength = KernelWidth*KernelHeight;

        /// <summary>
        /// Значение "1".
        /// </summary>
        public const int Bias = 1;

        /// <summary>
        /// Ширина карты признаков слоя 1.
        /// Вычисляется как количество шагов, за которое ядро доходит от левого края до правого.
        /// </summary>
        public const int L1MapWidth = (InputImageWidth - KernelWidth)/KernelStep + 1;

        /// <summary>
        /// Высота карты признаков слоя 1.
        /// Вычисляется как количество шагов, за которое ядро доходит от верхнего края до нижнего.
        /// </summary>
        public const int L1MapHeight = (InputImageHeight - KernelHeight)/KernelStep + 1;

        /// <summary>
        /// Количество нейронов на слое 1.
        /// 13px*13px*6карт = 1014 нейронов.
        /// </summary>
        public const int L1NeuronsCount = L1MapWidth*L1MapHeight*L1MapsCount;

        /// <summary>
        /// Количество весов в одной карте признаков слоя 1
        /// 25 на ядро + 1 биас = 26
        /// </summary>
        public const int L1InputsPerNeuron = KernelLength + Bias;

        /// <summary>
        /// Ширина карты признаков слоя 2.
        /// Вычисляется как количество шагов, за которое ядро доходит от левого края до правого.
        /// </summary>
        public const int L2MapWidth = (L1MapWidth - KernelWidth) / KernelStep + 1;

        /// <summary>
        /// Высота карты признаков слоя 1.
        /// Вычисляется как количество шагов, за которое ядро доходит от верхнего края до нижнего.
        /// </summary>
        public const int L2MapHeight = (L1MapHeight - KernelHeight) / KernelStep + 1;

        /// <summary>
        /// Количество нейронов на слое 2.
        /// 5px*5px*50 карт = 1250 нейронов.
        /// </summary>
        public const int L2NeuronsCount = L2MapWidth*L2MapHeight*L2MapsCount;

        /// <summary>
        /// Количество весов в одной карте признаков слоя 2.
        /// Каждый нейрон связан через общее ядро с картой признаков предыдущего слоя, и так для каждой карты.
        /// 25 на ядро*6 карт предыдущего слоя + 1 биас = 151 вес.
        /// </summary>
        public const int L2InputsPerNeuron = KernelLength*L1MapsCount + Bias;

        /// <summary>
        /// Количество весов у каждого нейрона слоя 3.
        /// Каждый нейрон связан со всеми нейронами слоя 2.
        /// 1250 нейронов предыдущего слоя + 1 биас = 1251 вес.
        /// </summary>
        public const int L3InputsPerNeuron = L2NeuronsCount + Bias;

        /// <summary>
        /// Количество весов у каждого нейрона слоя 3.
        /// Каждый нейрон связан со всеми нейронами слоя 2.
        /// 100 нейронов предыдущего слоя + 1 биас = 101 вес.
        /// </summary>
        public const int L4InputsPerNeuron = L3NeuronsCount + Bias;

        #endregion

        /// <summary>
        /// Возвращает все слои нейросети
        /// </summary>
        public Layer[] Layers { get; private set; }

        /// <summary>
        /// Возвращает входной слой нейросети
        /// </summary>
        public Layer2D InputLayer { get; private set; }

        /// <summary>
        /// Возвращает выходной слой нейросети
        /// </summary>
        public Layer OutputLayer { get; private set; }

        /// <summary>
        /// Возвращает объект, содержащий текущее состояние обучения сети
        /// </summary>
        public readonly NetworkTrainingInfo TrainingInfo = new NetworkTrainingInfo();

        public readonly KernelParams Kernel = new KernelParams(KernelWidth, KernelHeight, KernelStep);

        public Network()
        {
            // 0 слой - входной входных соединений нет
            InputLayer = new Layer2D(InputImageWidth, InputImageHeight, 0, 0);

            // 1 слой - сверточный, 156 весов, 26364 входных соединений
            var layer1 = new ConvolutionalLayer(L1MapsCount, L1MapWidth, L1MapHeight, L1InputsPerNeuron, Kernel);
            layer1.ConnectTo(InputLayer);

            // 2 слой - сверточный, 7550 весов, 188750 входных соединений
            var layer2 = new ConvolutionalLayer(L2MapsCount, L2MapWidth, L2MapHeight, L2InputsPerNeuron, Kernel);
            layer2.ConnectTo(layer1);

            // 3 слой - полносвязный, 125100 весов, 125100 соединений
            var layer3 = new Layer(L3NeuronsCount, L3InputsPerNeuron);
            layer3.ConnectTo(layer2);

            // 4 слой - полносвязный, 1010 весов, 1010 соединений
            OutputLayer = new Layer(L4NeuronsCount, L4InputsPerNeuron);
            OutputLayer.ConnectTo(layer3);

            for (int y = 0, n = 0; y < InputLayer.Height; y++)
            {
                for (var x = 0; x < InputLayer.Width; x++, n++)
                {
                    Debug.Assert(InputLayer.Neurons[n] == InputLayer.Neurons2D[y][x],
                                 string.Format("n => y, x: {0} => {1}, {2}", n, y, x));
                }
            }

            Layers = new[] { InputLayer, layer1, layer2, layer3, OutputLayer };
        }

        /// <summary>
        /// Возвращает выходной вектор, являющийся результатом прохождения через сеть входного.
        /// </summary>
        /// <param name="inputImage">Входной двумерный вектор</param>
        /// <returns>Выходной вектор-ответ</returns>
        public double[] Calculate(double[][] inputImage)
        {
            Debug.AssertEqualSize(inputImage, InputImageWidth, InputImageHeight);
            Debug.AssertValuesInRange(inputImage, -1.0, 1.0);

            PropagateForward(inputImage);

            return GetOutputVector();
        }

        /// <summary>
        /// Обучает сеть входному вектору, с учетом желаемого выходного вектора.
        /// Обучение происходит методом обратного распространения ошибки
        /// </summary>
        /// <param name="inputImage"></param>
        /// <param name="targetOutput"></param>
        public void Train(double[][] inputImage, double[] targetOutput)
        {
            Debug.AssertEqualSize(inputImage, InputImageWidth, InputImageHeight);
            Debug.Assert(targetOutput.Length == OutputLayer.Neurons.Length);
            
            // прогоняем картинку через сеть
            PropagateForward(inputImage);

            // подсчет mse
            var output = GetOutputVector();
            var mse = ArrayMath.CalculateMSE(output, targetOutput);

            // если она не мала, то обучаем сеть обратным распространением
            if (mse > 0.1*TrainingInfo.EpochMSE)
                PropagateBack(targetOutput);

            // обновляем статистику
            TrainingInfo.PushMeanSquaredError(mse);
            TrainingInfo.IncrementBackPropagationsCount();
        }

        private void PropagateForward(double[][] input2D)
        {
            for (var y = 0; y < input2D.Length; y++)
                for (var x = 0; x < input2D[y].Length; x++)
                    InputLayer.Neurons2D[y][x].Output = input2D[y][x];

            for (var i = 1; i < Layers.Length; i++)
                Layers[i].Calculate();
        }

        private void PropagateBack(double[] targetOutput)
        {
            for (var i = 0; i < OutputLayer.Neurons.Length; i++)
            {
                OutputLayer.Neurons[i].dEdX = OutputLayer.Neurons[i].Output - targetOutput[i];
            }

            // TODO incld last exlude first
            for (var l = Layers.Length - 1; l > 0; l--)
            {
                Layers[l].PropagateBack(TrainingInfo.CurrentLearningRate);
            }
        }

        // TODO
        private double[] GetOutputVector()
        {
            var outputLayer = Layers[Layers.Length - 1];
            var output = new double[outputLayer.Neurons.Length];
            for (var i = 0; i < output.Length; i++)
                output[i] = outputLayer.Neurons[i].Output;

            return output;
        }
    }
}
