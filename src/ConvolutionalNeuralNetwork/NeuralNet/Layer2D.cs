using Recognition.Image;
using Recognition.Utils;

namespace Recognition.NeuralNet
{
    public class Layer2D : Layer
    {
        public Neuron[][] Neurons2D { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public Layer2D(int width, int height, int inputsPerNeuron, int weightsCount)
            : base(width*height, inputsPerNeuron, weightsCount)
        {
            Neurons2D = ArrayHelper<Neuron>.Create2D(width, height, Neurons);
            Width = width;
            Height = height;
        }

        public override NormalizedImage ToNormalizedImage()
        {
            return new NormalizedImage(this);
        }
    }
}
