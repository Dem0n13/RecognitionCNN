using System;
using System.Diagnostics;

namespace Recognition.Utils
{
    public static class Debug
    {
        [Conditional("DEBUG")]
        public static void Assert(bool condition, string message = null)
        {
            if (!condition) throw new InvalidOperationException(message);
        }
        
        [Conditional("DEBUG")]
        public static void AssertNotNull<T>(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
        }

        [Conditional("DEBUG")]
        public static void AssertNotNull<T>(T[] vector)
        {
            if (vector == null) throw new ArgumentNullException("vector", "Vector");
            foreach (var item in vector) AssertNotNull(item);
        }

        [Conditional("DEBUG")]
        public static void AssertNotNull<T>(T[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException("matrix");
            foreach (var row in matrix)
                AssertNotNull(row);
        }

        [Conditional("DEBUG")]
        public static void AssertEqualSize<T>(T[] vector1, T[] vector2)
        {
            AssertNotNull(vector1);
            AssertNotNull(vector2);

            if (vector1.Length != vector2.Length) throw new ArgumentException("length");
        }

        [Conditional("DEBUG")]
        public static void AssertEqualSize<T>(T[][] matrix1, T[][] matrix2)
        {
            AssertNotNull(matrix1);
            AssertNotNull(matrix2);

            if (matrix1.Length != matrix2.Length) throw new ArgumentException("height");
            for (var row = 0; row < matrix1.Length; row++) AssertEqualSize(matrix1[row], matrix2[row]);
        }

        [Conditional("DEBUG")]
        public static void AssertEqualSize<T>(T[][] matrix1, int width2, int height2)
        {
            AssertNotNull(matrix1);

            if (matrix1.Length != height2) throw new ArgumentException("height");
            foreach (var row in matrix1)
                if (row.Length != width2) throw new ArgumentException("width");
        }

        [Conditional("DEBUG")]
        public static void AssertValuesInRange(double[] vector, double minValue, double maxValue)
        {
            AssertNotNull(vector);

            foreach (var value in vector)
                if (value < minValue || maxValue < value) throw new ArgumentOutOfRangeException("vector");
        }

        [Conditional("DEBUG")]
        public static void AssertValuesInRange(double[][] matrix, double minValue, double maxValue)
        {
            AssertNotNull(matrix);

            foreach (var row in matrix)
                AssertValuesInRange(row, minValue, maxValue);
        }
    }
}
