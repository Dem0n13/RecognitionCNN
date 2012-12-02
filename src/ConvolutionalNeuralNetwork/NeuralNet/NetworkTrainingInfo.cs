using System;
using System.Collections.Generic;
using Recognition.Utils;

namespace Recognition.NeuralNet
{
    public class NetworkTrainingInfo
    {
        public NetworkTrainingInfo()
        {
            _currentLearningRate = InitialLeaningRate;
            _epochMSE = InitialEpochMSE;
        }
        
        #region Константы (возможна инициализация из файла)

        /// <summary>
        /// Количество проходов, для которых собирается усредненная статистика
        /// </summary>
        public const int StatisticsItemsCount = 200;

        public const int EpochPeriod = 60000;
        public const int LearningRatePeriod = 2*EpochPeriod;

        public const double InitialLeaningRate = 0.001;
        public const double MinimumLeaningRate = 0.00005;
        public const double LeaningRateDecay = 0.794183335;

        public const double InitialEpochMSE = 0.1;

        #endregion

        #region Закрытые поля

        private double _summLastMSE;
        private double _summEpochMSE;
        private Queue<double> _avgMSEBag = new Queue<double>(StatisticsItemsCount);
        private int _backPropagationsCount;
        private int _epochsCount;
        private double _currentLearningRate;
        private double _epochMSE;

        #endregion
        
        /// <summary>
        /// Возвращает усредненную среднеквадратичную ошибку за последние несколько проходов
        /// или NaN, если статистика еще не набрана
        /// </summary>
        public double AverageMSE
        {
            get { return _summLastMSE/_avgMSEBag.Count; }
        }

        public int BackPropagationsCount
        {
            get { return _backPropagationsCount; }
        }

        public int EpochsCount
        {
            get { return _epochsCount; }
        }

        public double CurrentLearningRate
        {
            get { return _currentLearningRate; }
        }

        public double EpochMSE
        {
            get { return _epochMSE; }
        }

        /// <summary>
        /// Поместить новое значение среднеквадратичной ошибки для пересчета усредненного значения
        /// </summary>
        /// <param name="value"></param>
        public void PushMeanSquaredError(double value)
        {
            _summEpochMSE += value;

            if (_avgMSEBag.Count >= StatisticsItemsCount)
            {
                var oldestValue = _avgMSEBag.Dequeue();
                _summLastMSE += value - oldestValue;
                _avgMSEBag.Enqueue(value);
            }
            else
            {
                _summLastMSE += value;
                _avgMSEBag.Enqueue(value);
            }
        }

        public void IncrementBackPropagationsCount()
        {
            _backPropagationsCount++;

            // каждый период смены эпохи
            if (_backPropagationsCount%EpochPeriod == 0)
            {
                // пересчитываем ошибку эпохи и очищаем текущий накопитель
                _epochsCount++;
                _epochMSE = _summEpochMSE/(EpochPeriod*EpochsCount);
                _summEpochMSE = 0.0;
            }

            // каждый период смены коэффициента обучения
            if (_backPropagationsCount%LearningRatePeriod == 0)
            {
                // обновляем коэффициент до минимального порога
                var newLearningRate = _currentLearningRate*LeaningRateDecay;
                _currentLearningRate = Math.Max(newLearningRate, MinimumLeaningRate);
            }
        }

        public Dictionary<string, decimal> ToDictionary()
        {
            var result = new Dictionary<string, decimal>
                {
                    {"SummEpochMSE", (decimal) _summEpochMSE},
                    {"BackPropagationsCount", _backPropagationsCount},
                    {"EpochsCount", _epochsCount},
                    {"CurrentLearningRate", (decimal) _currentLearningRate},
                    {"EpochMSE", (decimal) _epochMSE}
                };

            return result;
        }

        public void FromDictionary(Dictionary<string, decimal> dictionary)
        {
            Debug.AssertNotNull(dictionary);

            decimal value;
            if (dictionary.TryGetValue("SummEpochMSE", out value))
                _summEpochMSE = (double) value;
            if (dictionary.TryGetValue("BackPropagationsCount", out value))
                _backPropagationsCount = (int) value;
            if (dictionary.TryGetValue("EpochsCount", out value))
                _epochsCount = (int) value;
            if (dictionary.TryGetValue("CurrentLearningRate", out value))
                _currentLearningRate = (double) value;
            if (dictionary.TryGetValue("EpochMSE", out value))
                _epochMSE = (double) value;
        }
    }
}
