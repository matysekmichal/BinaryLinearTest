using System.Diagnostics;

namespace Projekt1.AlgorithmsSearch
{
    public class LinearSearch : IAlgorithm
    {
        private int[] vector;
        private int numberToFind;
        private int _attempts = 100000000;

        public LinearSearch(int[] vector, int numberToFind)
        {
            this.vector = vector;
            this.numberToFind = numberToFind;
        }

        public void SetAttempts(int limit)
        {
            _attempts = limit;
        }

        public int AlgorithmInstrumentation()
        {
            throw new System.NotImplementedException();
        }

        public double AlgorithmSpeedTest()
        {
            long startTime = Stopwatch.GetTimestamp();

            for(var i = 0; i < _attempts; i++)
                LinearSearchAlgorithm();

            long stopTime = Stopwatch.GetTimestamp();

            return (stopTime - startTime) / (double)Stopwatch.Frequency;
        }

        public bool LinearSearchAlgorithm()
        {
            foreach (int t in vector)
                if (t == numberToFind)
                    return true;

            return false;
        }
    }
}