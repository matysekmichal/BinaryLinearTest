using System;
using System.IO;
using System.Diagnostics;
using System.Numerics;
using Project.BinarySearch;

namespace Project
{
    internal class App
    {
        private const int ArrayLength = 256 * 1024 * 1024 - 1;

        public static void Main(string[] args)
        {
            int[] arrayOfNumbers = generateNextNumbers(ArrayLength);

            for(int i = 10; i <= 28; i++)
            {
                int arrayLengthToMeassure = (1 << i) - 1;

                double binarySearchSpeedTest = new BinarySearch.BinarySearch(arrayOfNumbers, 0, arrayLengthToMeassure).BinarySearchSpeedTest();

                Console.WriteLine(binarySearchSpeedTest);
            }
        }

        private static int[] generateNextNumbers(int arrayLength)
        {
            int[] arrayOfNumbers = new int[arrayLength];

            for(int i = 0; i < arrayOfNumbers.Length; i++)
                arrayOfNumbers[i] = i + 1;

            return arrayOfNumbers;
        }
    }
}