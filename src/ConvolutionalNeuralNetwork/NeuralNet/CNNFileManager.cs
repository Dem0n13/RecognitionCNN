using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;

namespace Recognition.NeuralNet
{
    public static class CNNFileManager
    {
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        static CNNFileManager()
        {
            Serializer.MaxJsonLength = int.MaxValue;
        }

        public static Network GetNetwork(string path)
        {
            Debug.Assert(path != null);

            var data = File.ReadAllText(path);
            var network = new Network();
            var info = Serializer.Deserialize<NetworkSerializeInfo>(data);
            info.LoadDataTo(network);

            return network;
        }

        public static void SaveNetwork(Network network, string path)
        {
            Debug.Assert(path != null);

            var info = new NetworkSerializeInfo();
            info.GetDataFrom(network);
            var data = Serializer.Serialize(info);
            File.WriteAllText(path, data);
        }

        private class NetworkSerializeInfo
        {
            public Dictionary<string, decimal> StateInfo;
            public double[][] WeightsInfo;
            
            public void GetDataFrom(Network network)
            {
                Debug.Assert(network != null);

                StateInfo = network.TrainingInfo.ToDictionary();

                WeightsInfo = new double[network.Layers.Length][];
                for (var l = 0; l < WeightsInfo.Length; l++)
                {
                    var layer = network.Layers[l];
                    WeightsInfo[l] = new double[layer.Weights.Length];
                    for (var w = 0; w < WeightsInfo[l].Length; w++)
                    {
                        WeightsInfo[l][w] = layer.Weights[w].Value;
                    }
                }
            }

            public void LoadDataTo(Network network)
            {
                Debug.Assert(network != null);
                // TODO debug asserts

                network.TrainingInfo.FromDictionary(StateInfo);

                for (var l = 0; l < WeightsInfo.Length; l++)
                {
                    var layer = network.Layers[l];
                    for (var w = 0; w < WeightsInfo[l].Length; w++)
                    {
                        layer.Weights[w].Value = WeightsInfo[l][w];
                    }
                }
            }
        }
    }
}
