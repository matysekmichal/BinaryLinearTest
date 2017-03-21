using System;

namespace Projekt1
{
    internal class App
    {
        private const int ArrayLength = 256 * 1024 * 1024 - 1;

        public static void Main(string[] args)
        {
            int[] arrayOfNumbers = generateNextNumbers(ArrayLength);

            int numberToFind = 123663;
            double binarySearchAlgorithm = new BinarySearch.BinarySearch(arrayOfNumbers, numberToFind).BinarySearchAlgorithm();

            if (binarySearchAlgorithm > 0)
                Console.WriteLine("Liczba {0} znajduje się na pozycji {1}.", numberToFind, binarySearchAlgorithm);
            else
                Console.WriteLine("Nie znaleziono liczby {0}.", numberToFind);

            for(int i = 10; i <= 28; i++)
            {
                int arrayLengthToMeassure = (1 << i) - 1;

                BinarySearch.BinarySearch binarySearchSpeedTest = new BinarySearch.BinarySearch(arrayOfNumbers, 0);
                binarySearchSpeedTest.SetLimitArrayToCheck(arrayLengthToMeassure);

                double time = binarySearchSpeedTest.BinarySearchSpeedTest();

                Console.WriteLine("{0}; {1}; {2}", i, arrayLengthToMeassure, time);
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