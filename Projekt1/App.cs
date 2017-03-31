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

//            Console.WriteLine("1. Binary test:");
//            ComposeBinarySearchTest(arrayOfNumbers);
            Console.WriteLine("2. Binary speed test:");
            ComposeBinarySearchSpeedTest(arrayOfNumbers);
//            Console.WriteLine("3. Linear test:");
//            ComposeLinearSearchTest(arrayOfNumbers);
//            Console.WriteLine("4. Linear speed test.");
//            ComposeLinearSearchSpeedTest(arrayOfNumbers);
        }

        private static void ComposeLinearSearchTest(int[] arrayOfNumbers)
        {
            SaveToFile file = new SaveToFile("LinearSearchTest.csv");

            LinearSearch linearSearchAlgorithm = new LinearSearch(arrayOfNumbers);

            for (int i = 1; i <= 28; i++)
            {
                linearSearchAlgorithm.SetNumberToFind(i);
                linearSearchAlgorithm.AlgorithmInstrumentation();

                var stream = linearSearchAlgorithm.GetInstrumentation();
                Console.WriteLine(stream);
                file.SetStream(stream);
            }

            file.Save();
        }

        private static void ComposeLinearSearchSpeedTest(int[] arrayOfNumbers)
        {
            SaveToFile file = new SaveToFile("LinearSearchSpeedTest.csv");

            LinearSearch linearSearchSpeedTest = new LinearSearch(arrayOfNumbers);

            for(int i = 1; i <= 28; i++)
            {
                linearSearchSpeedTest.SetNumberToFind(i);

                double time = linearSearchSpeedTest.AlgorithmSpeedTest();

                string stream = $"{i}; {time}";

                file.SetStream(stream);
                Console.WriteLine(stream);
            }

            file.Save();
        }

        private static void ComposeBinarySearchSpeedTest(int[] arrayOfNumbers)
        {
            SaveToFile file = new SaveToFile("BinarySearchSpeedTest.csv");

            BinarySearch binarySearchSpeedTest = new BinarySearch(arrayOfNumbers);

            for(int i = 1; i <= 28; i++)
            {
                binarySearchSpeedTest.SetNumberToFind(i);

                double time = binarySearchSpeedTest.AlgorithmSpeedTest();

                string stream = $"{i}; {time}";

                file.SetStream(stream);
                Console.WriteLine(stream);
            }

            file.Save();
        }

        private static void ComposeBinarySearchTest(int[] arrayOfNumbers)
        {
            SaveToFile file = new SaveToFile("BinarySearchTest.csv");

            BinarySearch binarySearchAlgorithm = new BinarySearch(arrayOfNumbers);

            for (int i = 1; i <= 28; i++)
            {
                binarySearchAlgorithm.SetNumberToFind(i);
                binarySearchAlgorithm.AlgorithmInstrumentation();

                var stream = binarySearchAlgorithm.GetInstrumentation();
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