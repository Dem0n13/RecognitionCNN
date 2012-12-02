using Recognition.Image;

namespace Recognition.NeuralNet
{
    /// <summary>
    /// Обычный нейронный слой, состоящий из нейронов и весов
    /// Класс является базовым для всех остальных типов слоев
    /// </summary>
    public class Layer
    {
        /// <summary>
        /// Массив нейронов
        /// </summary>
        public Neuron[] Neurons { get; protected set; }

        /// <summary>
        /// Массив весов
        /// </summary>
        public Weight[] Weights { get; protected set; }

        // Для ручного заполнения
        protected Layer()
        {
        }

        /// <summary>
        /// Инициализирует слой по умолчанию с указанным количество нейронов и количеством соединений на один нейрон.
        /// При этом, количество весов слоя устанавливается по умолчанию, на каждое соединение по своему весу.
        /// </summary>
        /// <param name="neuronsCount"></param>
        /// <param name="inputsPerNeuron"></param>
        public Layer(int neuronsCount, int inputsPerNeuron)
            : this(neuronsCount, inputsPerNeuron, inputsPerNeuron*neuronsCount)
        {
        }

        /// <summary>
        /// Инициализирует слой по умолчанию с указанным количество нейронов и количеством соединений на один нейрон и количеством весов на слой.
        /// </summary>
        /// <param name="neuronsCount"></param>
        /// <param name="inputsPerNeuron"></param>
        /// <param name="weightsCount"></param>
        public Layer(int neuronsCount, int inputsPerNeuron, int weightsCount)
        {
            Neurons = new Neuron[neuronsCount];
            for (var i = 0; i < Neurons.Length; i++)
            {
                Neurons[i] = new Neuron(inputsPerNeuron);
            }

            Weights = new Weight[weightsCount];
            for (var i = 0; i < Weights.Length; i++)
            {
                Weights[i] = new Weight();
            }
        }

        /// <summary>
        /// Обеспечивает полносвязное соединение слоя с выходами входного слоя
        /// </summary>
        /// <param name="inputLayer">Входной слой</param>
        public virtual void ConnectTo(Layer inputLayer)
        {
            // подключение всех нейронов к предыдущему слою
            for (int neuronIndex = 0, weightIndex = 0; neuronIndex < Neurons.Length; neuronIndex++)
            {
                var neuron = Neurons[neuronIndex];

                // заполнение входных соединений нейрона:
                // используем все выходы входного слоя + биас
                int ci;
                for (ci = 0; ci < inputLayer.Neurons.Length; ci++)
                {
                    var inputNeuron = inputLayer.Neurons[ci];
                    var weidth = Weights[weightIndex++];
                    neuron.InputConnections[ci] = new InputConnection(inputNeuron, weidth);
                }

                var biasWeight = Weights[weightIndex++];
                neuron.InputConnections[ci] = new InputConnection(Neuron.Bias, biasWeight);
            }
        }

        public void Calculate()
        {
            foreach (var neuron in Neurons)
            {
                neuron.Calculate();
            }
        }

        public void PropagateBack(double learningRate)
        {
            // сброс ошибки по весу dEdW(i) = 0
            foreach (var weight in Weights)
                weight.dEdW = 0.0;

            // накопление ошибки для каждого веса dEdW(i) = x(i-1)*dEdY(i)
            // сброс ошибки предыдущего слоя dEdX(i-1) = 0
            foreach (var neuron in Neurons)
            {
                foreach (var connection in neuron.InputConnections)
                {
                    connection.Weight.dEdW += connection.Neuron.Output*neuron.dEdY;
                    connection.Neuron.dEdX = 0.0;
                }
            }

            // накопление ошибки на предыдущий слой dEdX(i-1) = w(i)*dEdY(i)
            foreach (var neuron in Neurons)
            {
                foreach (var connection in neuron.InputConnections)
                {
                    connection.Neuron.dEdX += neuron.dEdY*connection.Weight.Value;
                }
            }

            // обновление весов W -= eta*dEdW(i)
            foreach (var weight in Weights)
            {
                var epsilon = learningRate; // TODO etaLearningRate / ( m_Weights[ jj ]->diagHessian + dMicron) ; 
                weight.Value -= epsilon*weight.dEdW;
            }
        }

        public virtual NormalizedImage ToNormalizedImage()
        {
            return new NormalizedImage(this);
        }
    }
}