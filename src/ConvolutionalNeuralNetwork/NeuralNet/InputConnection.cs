namespace Recognition.NeuralNet
{
    public class InputConnection
    {
        public Neuron Neuron { get; private set; }
        public Weight Weight { get; private set; }

        public InputConnection(Neuron neuron, Weight weight)
        {
            Neuron = neuron;
            Weight = weight;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Neuron != null ? Neuron.ToString() : "Bias", Weight);
        }
    }
}