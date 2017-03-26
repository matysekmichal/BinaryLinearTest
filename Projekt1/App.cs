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

            ComposeBinarySearchTest(arrayOfNumbers);
            ComposeBinarySearchSpeedTest(arrayOfNumbers);
            ComposeLinearSearchTest(arrayOfNumbers);
            ComposeLinearSearchSpeedTest(arrayOfNumbers);
        }

        private static void ComposeLinearSearchTest(int[] arrayOfNumbers)
        {
            string stream;
            SaveToFile file = new SaveToFile("LinearSearchTest.csv");

            LinearSearch linearSearchAlgorithm = new LinearSearch(arrayOfNumbers);

            for (int i = 1; i <= 28; i++)
            {
                linearSearchAlgorithm.SetNumberToFind(i);
                linearSearchAlgorithm.AlgorithmInstrumentation();

                stream = linearSearchAlgorithm.GetInstrumentation();
                Console.WriteLine(stream);
                file.SetStream(stream);
            }

            file.Save();
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
            string stream;
            SaveToFile file = new SaveToFile("BinarySearchSpeedTest.csv");

            for(int i = 10; i <= 28; i++)
            {
                int arrayLengthToMeassure = (1 << i) - 1;

                BinarySearch binarySearchSpeedTest = new BinarySearch(arrayOfNumbers, 0);
                binarySearchSpeedTest.SetLimitArrayToCheck(arrayLengthToMeassure);

                double time = binarySearchSpeedTest.AlgorithmSpeedTest();

                stream = $"{i}; {arrayLengthToMeassure}; {time}";

                file.SetStream(stream);
                Console.WriteLine(stream);
            }

            file.Save();
        }

        private static void ComposeBinarySearchTest(int[] arrayOfNumbers)
        {
            string stream;
            SaveToFile file = new SaveToFile("BinarySearchTest.csv");

            BinarySearch binarySearchAlgorithm = new BinarySearch(arrayOfNumbers);

            for (int i = 1; i <= 28; i++)
            {
                binarySearchAlgorithm.SetNumberToFind(i);
                binarySearchAlgorithm.AlgorithmInstrumentation();

                stream = binarySearchAlgorithm.GetInstrumentation();
                Console.WriteLine(stream);
                file.SetStream(stream);
            }

            file.Save();
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