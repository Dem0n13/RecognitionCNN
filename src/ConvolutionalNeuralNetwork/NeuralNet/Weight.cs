using System;
using System.Runtime.Serialization;

namespace Recognition.NeuralNet
{
    [DataContract]
    public class Weight
    {
        private static readonly Random Random = new Random();
        
        public string Label { get; set; }

        [DataMember]
        public double Value { get; set; }
        
        /// <summary>
        /// Дифференциал ошибки по весу
        /// </summary>
        public double dEdW { get; set; }

        public Weight()
        {
            Value = 0.05*GetPlusMinusOneRandom();
        }

        private static double GetPlusMinusOneRandom()
        {
            return 2.0*Random.NextDouble() - 1.0;
        }

        public override string ToString()
        {
            return (Label ?? "L?") + ": " + Value;
        }
    }
}