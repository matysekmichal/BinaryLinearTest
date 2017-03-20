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
                int number = (1 << i) - 1;

                double durationTime = Test(arrayOfNumbers, number);
                Console.WriteLine($"attempt = {i}, number = {number}, duration = {durationTime}");

                file.WriteLine(string.Format($"{i}; {number}; {durationTime}"));
            }

            file.Dispose();
        }

        private static int BinarySearch(int[] vector, int number, int numberToFind)
        {
            int left = 0;
            int right = number - 1;

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

        private static double Test(int[] vector, int number)
        {
            const int attempts = 100000000;

            long startTime = Stopwatch.GetTimestamp();

            for(var i = 0; i < attempts; i++)
                BinarySearch(vector, number, 0);

            long stopTime = Stopwatch.GetTimestamp();

            return (stopTime - startTime) / (double)Stopwatch.Frequency;
        }
    }
}