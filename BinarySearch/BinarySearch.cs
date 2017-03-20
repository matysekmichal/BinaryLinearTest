using System.Diagnostics;

namespace Project.BinarySearch
{
    public class BinarySearch : BinarySearchInterface
    {
        private int[] vector;
        private int numberToFind;
        private int arrayLengthToMeassure;
        private int attempts = 100000000;

        public BinarySearch(int[] vector, int numberToFind)
        {
            this.vector = vector;
            this.numberToFind = numberToFind;
            arrayLengthToMeassure = vector.Length;
        }

        public BinarySearch(int[] vector, int numberToFind, int arrayLengthToMeassure, int attempts = 100000000)
        {
            this.vector = vector;
            this.numberToFind = numberToFind;
            this.arrayLengthToMeassure = arrayLengthToMeassure;
            this.attempts = attempts;
        }

        public double BinarySearchSpeedTest()
        {
            long startTime = Stopwatch.GetTimestamp();

            for(var i = 0; i < attempts; i++)
                BinarySearchAlgorithm();

            long stopTime = Stopwatch.GetTimestamp();

            return (stopTime - startTime) / (double)Stopwatch.Frequency;
        }

        public int BinarySearchAlgorithm()
        {
            int left = 0;
            int right = arrayLengthToMeassure - 1;

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