using System;
using Recognition.Utils;

namespace Recognition.NeuralNet
{
    /// <summary>
    /// Карта признаков. Является 2D слоем, нейроны которого делят общие веса (количество соединений нейрона = количеству весов слоя)
    /// </summary>
    public sealed class FeatureMap : Layer2D
    {
        /// <summary>
        /// Инициализирует новую карту признаков с указанной шириной, высотой и количеством весов.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="weightsCount"></param>
        public FeatureMap(int width, int height, int weightsCount)
            : base(width, height, weightsCount, weightsCount)
        {
        }

        public override void ConnectTo(Layer inputLayer)
        {
            throw new InvalidOperationException("Нельзя присоединить карту признаков к линейному слою.");
        }

        public void ConnectTo(Layer2D inputLayer, KernelParams kernel)
        {
            var inputsCounter = 0;
            ConnectWithoutBiasTo(inputLayer, kernel, ref inputsCounter);
            ConnectLastToBias();
        }

        public void ConnectTo(ConvolutionalLayer inputLayer, KernelParams kernel)
        {
            // поочередно подключаем карту к каждой карте входного слоя, 
            var inputsCounter = 0;
            foreach (var featureMap in inputLayer.FeatureMaps)
                ConnectWithoutBiasTo(featureMap, kernel, ref inputsCounter);

            ConnectLastToBias();
        }

        /// <summary>
        /// Присоединяет карту к двумерному массиву нейронов без биаса.
        /// Так как карт может быть несколько, передается переменная-счетчик подключений карты
        /// </summary>
        /// <param name="inputMap"></param>
        /// <param name="kernel"></param>
        /// <param name="inputsCounter"></param>
        private void ConnectWithoutBiasTo(Layer2D inputMap, KernelParams kernel, ref int inputsCounter)
        {
            // заполнение карты слоя
            for (var mapY = 0; mapY < Height; mapY++)
            {
                for (var mapX = 0; mapX < Width; mapX++)
                {
                    // обрабатываемый нейрон
                    var neuron = Neurons2D[mapY][mapX];

                    var i = 0;

                    // обрабатываем ядро 5*5, заполняя соединения
                    // начало ядра перемещается по 2 пиксела вправо и вниз для каждой карты
                    for (var kY = mapY*kernel.Step; kY < mapY*kernel.Step + kernel.Height; kY++)
                    {
                        for (var kX = mapX*kernel.Step; kX < mapX*kernel.Step + kernel.Width; kX++)
                        {
                            // подключаем нейрон с предыдущего слоя через ядро весов
                            var inputNeuron = inputMap.Neurons2D[kY][kX];
                            var weight = Weights[inputsCounter + i];
                            neuron.InputConnections[inputsCounter + i] = new InputConnection(inputNeuron, weight);
                            i++;
                        }
                    }
                }
            }

            // присоединен еще один входной слой
            inputsCounter += kernel.Length;
        }

        /// <summary>
        /// Использует последнее входное подключение каждого нейрона карты как биас
        /// </summary>
        private void ConnectLastToBias()
        {
            // добавляем биас последним соединением нейрона
            var lastWeight = Weights[Weights.GetUpperBound(0)];
            foreach (var neuron in Neurons)
            {
                neuron.InputConnections[neuron.InputConnections.GetUpperBound(0)]
                    = new InputConnection(Neuron.Bias, lastWeight);
            }
        }
    }
}