using System;

namespace Recognition.NeuralNet
{
    public class Neuron
    {
        #region Статические члены

        public static readonly Neuron Bias = new Neuron(0);
        static Neuron()
        {
            Bias.Label = "Bias";
            Bias.Output = 1.0;
        }

        public static double Sigmoid(double x)
        {
            return 1.7159 * Math.Tanh(0.66666667 * x);
        }

        public static double DSigmoid(double x)
        {
            return 0.66666667/1.7159*(1.7159 + x)*(1.7159 - x);
        }

        #endregion

        public readonly InputConnection[] InputConnections;

        private double _dOutput;
        private double _output;

        public double Output
        {
            get { return _output; }
            set
            {
                
                _dOutput = DSigmoid(value);
                _output = value;
            }
        }
        public double dEdX { get; set; }
        public double dEdY { get { return _dOutput * dEdX; } }
        public string Label { get; set; }

        public Neuron(int inputConnectionsCount)
        {
            InputConnections = new InputConnection[inputConnectionsCount];
        }

        public void Calculate()
        {
            var connections = InputConnections;
            var sum = 0.0;

            for (var i = 0; i < InputConnections.Length; i++)
            {
                sum += connections[i].Neuron.Output * connections[i].Weight.Value;
            }

            Output = Sigmoid(sum);
        }

        public override string ToString()
        {
            return Label ?? base.ToString();
        }
    }
}
