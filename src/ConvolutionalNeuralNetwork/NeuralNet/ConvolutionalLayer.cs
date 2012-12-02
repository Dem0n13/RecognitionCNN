using Recognition.Image;
using Recognition.Utils;

namespace Recognition.NeuralNet
{
    public sealed class ConvolutionalLayer : Layer
    {
        private readonly KernelParams _kernel;
        public readonly FeatureMap[] FeatureMaps;

        public ConvolutionalLayer(int mapsCount, int mapWidth, int mapHeight, int inputsPerNeuron, KernelParams kernel)
        {
            // инициализация вручную. Создается пустой слой, затем карты признаков и из них копируются ссылки на нейроны и весы самого слоя
            FeatureMaps = new FeatureMap[mapsCount];
            Neurons = new Neuron[mapWidth*mapHeight*mapsCount];
            Weights = new Weight[inputsPerNeuron*mapsCount];

            for (int fi = 0, w = 0, n = 0; fi < FeatureMaps.Length; fi++)
            {
                // создаем очередную карту признаков - 2D слой
                FeatureMaps[fi] = new FeatureMap(mapWidth, mapHeight, inputsPerNeuron);

                // заполняем из новой карты признаков основные массивы слоя - нейроны и веса
                foreach (var neuron in FeatureMaps[fi].Neurons)
                    Neurons[n++] = neuron;
                foreach (var weight in FeatureMaps[fi].Weights)
                    Weights[w++] = weight;
            }

            _kernel = kernel;
        }

        #region Методы присоединения к другим слоям

        public override void ConnectTo(Layer inputLayer)
        {
            foreach (var featureMap in FeatureMaps)
            {
                featureMap.ConnectTo(inputLayer);
            }
        }

        /// <summary>
        /// Обеспечивает соединение каждой карты признаков со входным 2D-слоем.
        /// </summary>
        /// <param name="inputLayer">Входной сверточный 2D-слой.</param>
        public void ConnectTo(Layer2D inputLayer)
        {
            // каждую карту признаков подключаем к входному слою
            foreach (var featureMap in FeatureMaps)
            {
                featureMap.ConnectTo(inputLayer, _kernel);
            }
        }

        /// <summary>
        /// Обеспечивает соединение каждой карты признаков с каждой картой признаков входного сверточного слоя.
        /// </summary>
        /// <param name="inputLayer">Входной сверточный слой.</param>
        public void ConnectTo(ConvolutionalLayer inputLayer)
        {
            // каждую карту признаков подключаем к входному слою
            foreach (var featureMap in FeatureMaps)
            {
                featureMap.ConnectTo(inputLayer, _kernel);
            }
        }

        #endregion

        public override NormalizedImage ToNormalizedImage()
        {
            return new NormalizedImage(this);
        }
    }
}