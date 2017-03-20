using System;
using System.IO;
using System.Diagnostics;

namespace Project
{
    internal class App
    {
        private const int ArrayLength = 256 * 1024 * 1024 - 1;

        public static void Main(string[] args)
        {
            FileStream scoresFile = File.Create("scores.csv");
            StreamWriter file = new StreamWriter(scoresFile);

            int[] arrayOfNumbers = new int[ArrayLength];

            for(int i = 0; i < arrayOfNumbers.Length; i++)
                arrayOfNumbers[i] = i + 1;

            for(int i = 10; i <= 28; i++)
            {
                int arrayLengthToMeassure = (1 << i) - 1;

                double durationTime = Test(arrayOfNumbers, arrayLengthToMeassure);
                Console.WriteLine($"attempt = {i}, arrayLengthToMeassure = {arrayLengthToMeassure}, duration = {durationTime}");

                file.WriteLine(string.Format($"{i}; {arrayLengthToMeassure}; {durationTime}"));
            }

            file.Dispose();
        }

        private static int BinarySearch(int[] vector, int arrayLengthToMeassure, int numberToFind)
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

        private static double Test(int[] vector, int arrayLengthToMeassure)
        {
            const int attempts = 100000000;

            long startTime = Stopwatch.GetTimestamp();

            for(var i = 0; i < attempts; i++)
                BinarySearch(vector, arrayLengthToMeassure, 0);

            long stopTime = Stopwatch.GetTimestamp();

            return (stopTime - startTime) / (double)Stopwatch.Frequency;
        }
    }
}