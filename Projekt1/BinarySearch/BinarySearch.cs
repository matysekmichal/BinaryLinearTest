using System.Diagnostics;

namespace Project.BinarySearch
{
    public class BinarySearch : BinarySearchInterface
    {
        private int[] vector;
        private int numberToFind;
        private int arrayLengthToMeassure;

        BinarySearch()
        {
            return BinarySearchSpeedTest();
        }

        private double BinarySearchSpeedTest()
        {
            const int attempts = 100000000;

            long startTime = Stopwatch.GetTimestamp();

            for(var i = 0; i < attempts; i++)
                BinarySearch(vector, arrayLengthToMeassure, 0);

            long stopTime = Stopwatch.GetTimestamp();

            return (stopTime - startTime) / (double)Stopwatch.Frequency;
        }

        private int BinarySearch()
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