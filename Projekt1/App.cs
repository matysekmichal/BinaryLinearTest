using System;
using Projekt1.AlgorithmsSearch;

namespace Projekt1
{
    internal class App
    {
        private const int ArrayLength = 256 * 1024 * 1024 - 1;

        public static void Main(string[] args)
        {
            int[] arrayOfNumbers = GenerateNextNumbers(ArrayLength);
            int numberToFind = 2;

//            ComposeBinarySearchTest(arrayOfNumbers, numberToFind);
//            ComposeBinarySearchSpeedTest(arrayOfNumbers);
            ComposeLinearSearchTest(arrayOfNumbers, numberToFind);
            ComposeLinearSearchSpeedTest(arrayOfNumbers);
        }

        private static void ComposeLinearSearchTest(int[] arrayOfNumbers, int numberToFind)
        {
            LinearSearch linearSearchAlgorithm = new LinearSearch(arrayOfNumbers, numberToFind);
            int result = linearSearchAlgorithm.AlgorithmInstrumentation();

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(linearSearchAlgorithm.GetInstrumentation());
            }
        }

        private static void ComposeLinearSearchSpeedTest(int[] arrayOfNumbers)
        {
            string stream;
            SaveToFile file = new SaveToFile("LinearSearchSpeedTest.csv");

            for(int i = 1; i <= 5; i++)
            {
                int arrayLengthToMeassure = (1 << i) - 1;

                LinearSearch linearSearchSpeedTest = new LinearSearch(arrayOfNumbers, i);

                double time = linearSearchSpeedTest.AlgorithmSpeedTest();

                stream = $"{i}; {arrayLengthToMeassure}; {time}";

                file.SetStream(stream);
                Console.WriteLine(stream);
            }

            file.Save();
        }

        private static void ComposeBinarySearchSpeedTest(int[] arrayOfNumbers)
        {
            for(int i = 10; i <= 28; i++)
            {
                int arrayLengthToMeassure = (1 << i) - 1;

                BinarySearch binarySearchSpeedTest = new BinarySearch(arrayOfNumbers, 0);
                binarySearchSpeedTest.SetLimitArrayToCheck(arrayLengthToMeassure);

                double time = binarySearchSpeedTest.AlgorithmSpeedTest();

                Console.WriteLine("{0}; {1}; {2}", i, arrayLengthToMeassure, time);
            }
        }

        private static void ComposeBinarySearchTest(int[] arrayOfNumbers, int numberToFind)
        {
            int binarySearchAlgorithm = new BinarySearch(arrayOfNumbers, numberToFind).BinarySearchAlgorithm();

            if (binarySearchAlgorithm > 0)
                Console.WriteLine("Liczba {0} znajduje się na pozycji {1}.", numberToFind, binarySearchAlgorithm);
            else
                Console.WriteLine("Nie znaleziono liczby {0}.", numberToFind);
        }

        private static int[] GenerateNextNumbers(int arrayLength)
        {
            int[] arrayOfNumbers = new int[arrayLength];

            for(int i = 0; i < arrayOfNumbers.Length; i++)
                arrayOfNumbers[i] = i + 1;

            return arrayOfNumbers;
        }
    }
}