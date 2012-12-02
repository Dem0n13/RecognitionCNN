using System;

namespace Recognition.Utils
{
    public static class ArrayHelper<T>
    {
        public static T[] Create(int count)
        {
            return new T[count];
        }

        public static T[] Create(int count, T initValue)
        {
            var vector = new T[count];
            for (var i = 0; i < count; i++)
                vector[i] = initValue;
            return vector;
        }

        public static T[][] Create2D(int columnsCount, int rowsCount)
        {
            var matrix = new T[rowsCount][];
            for (var i = 0; i < rowsCount; i++)
                matrix[i] = Create(columnsCount);
            return matrix;
        }

        public static T[][] Create2D(int columnsCount, int rowsCount, T initValue)
        {
            var matrix = new T[rowsCount][];
            for (var i = 0; i < rowsCount; i++)
                matrix[i] = Create(columnsCount, initValue);
            return matrix;
        }

        public static T[][] Create2D(int columnsCount, int rowsCount, T[] initVector)
        {
            //TODO
            
            var matrix = new T[rowsCount][];
            for (int row = 0, n = 0; row < rowsCount; row++)
            {
                matrix[row] = Create(columnsCount);
                for (var col = 0; col < columnsCount; col++, n++)
                {
                    matrix[row][col] = initVector[n];
                }
            }
            return matrix;
        }

        public static void CopyData(T[] src, T[][] dest, int row, int startCol)
        {
            Array.Copy(src, 0, dest[row], startCol, src.Length);
        }

        public static void CopyData(T[][] src, T[][] dest, int startRow, int startCol)
        {
            for (var srcRow = 0; srcRow < src.Length; srcRow++)
                CopyData(src[srcRow], dest, startRow + srcRow, startCol);
        }

        public static void CopyData(T[][] src, T[][] dest)
        {
            CopyData(src, dest, 0, 0);
        }

        /// <summary>
        /// Возвращает массив указанной длины, заполненный фоновым значением
        /// и по указанному индексу будет распологаться оригинальное значение
        /// </summary>
        /// <typeparam name="T">Тип элементов массива</typeparam>
        /// <param name="length">Длина возвращаемого массива</param>
        /// <param name="backValue">Фоновое значение - заполнитель массива</param>
        /// <param name="frontValueIndex">Индекс оригинального значения</param>
        /// <param name="frontValue">Оригинальное значение</param>
        /// <returns></returns>
        public static T[] CreateScalar(int length, T backValue, int frontValueIndex, T frontValue)
        {
            Debug.Assert(length > frontValueIndex);

            var result = new T[length];
            for (var i = 0; i < length; i++)
                result[i] = backValue;
            result[frontValueIndex] = frontValue;
            return result;
        }

        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Перемешивает элементы массива случайным образом.
        /// Алгоритм перемешивания Fisher–Yates shuffle:
        /// http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_modern_algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void Shuffle(T[] array)
        {
            for (var i = array.Length - 1; i > 0; i--)
            {
                var j = Rnd.Next(i + 1);
                var buffer = array[i];
                array[i] = array[j];
                array[j] = buffer;
            }
        }
    }
}
