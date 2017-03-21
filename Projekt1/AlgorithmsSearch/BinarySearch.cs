using System.Diagnostics;

namespace Projekt1.AlgorithmsSearch
{
    public class BinarySearch : IAlgorithm
    {
        private int[] vector;
        private int numberToFind;
        private int _arrayLengthToMeassure;
        private int _attempts = 100000000;

        public BinarySearch(int[] vector, int numberToFind)
        {
            this.vector = vector;
            this.numberToFind = numberToFind;
            _arrayLengthToMeassure = vector.Length;
        }

        public void SetLimitArrayToCheck(int limit)
        {
            _arrayLengthToMeassure = limit < vector.Length ? limit : vector.Length;
        }

        public void SetAttempts(int limit)
        {
            _attempts = limit;
        }

        public double BinarySearchSpeedTest()
        {
            long startTime = Stopwatch.GetTimestamp();

            for(var i = 0; i < _attempts; i++)
                BinarySearchAlgorithm();

            long stopTime = Stopwatch.GetTimestamp();

            return (stopTime - startTime) / (double)Stopwatch.Frequency;
        }

        public int BinarySearchAlgorithm()
        {
            int left = 0;
            int right = _arrayLengthToMeassure - 1;

            while(left <= right)
            {
                int middle = (left + right) >> 1;

                if (vector[middle] == numberToFind)
                    return middle;
                if (vector[middle] > numberToFind)
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }
    }
}