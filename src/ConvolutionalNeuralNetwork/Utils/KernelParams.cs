namespace Recognition.Utils
{
    public struct KernelParams
    {
        public readonly int Width;
        public readonly int Height;
        public readonly int Length;
        public readonly int Step;

        public KernelParams(int width, int height, int step)
        {
            Width = width;
            Height = height;
            Length = width*height;
            Step = step;
        }
    }
}