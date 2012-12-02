namespace Recognition.Utils
{
    public static class ArrayMath
    {
        public static double CalculateMSE(double[] resultVector, double[] desiredVector)
        {
            Debug.AssertEqualSize(resultVector, desiredVector);

            // подсчитываем среднюю квадратичную ошибку сети
            var mse = 0.0;
            for (var i = 0; i < resultVector.Length; i++)
                mse += (resultVector[i] - desiredVector[i]) *
                       (resultVector[i] - desiredVector[i]);
            return mse / 2.0;
        }

        public static int MaxValueIndex(double[] vector)
        {
            Debug.AssertNotNull(vector);
            
            var maxValueIndex = 0;
            for (var i = 1; i < vector.Length; i++)
                if (vector[i] > vector[maxValueIndex]) maxValueIndex = i;
            return maxValueIndex;
        }
    }
}
