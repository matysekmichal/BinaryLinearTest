﻿using System.Diagnostics;

namespace Projekt1.AlgorithmsSearch
{
    public class LinearSearch : IAlgorithm
    {
        private int[] vector;
        private int _numberToFind;
        private int _attempts = 100000000;
        public int OpAssignment;
        public int OpComparisonLt;
        public int OpComparisonEq;
        public int OpIncrement;

        public LinearSearch(int[] vector)
        {
            this.vector = vector;
        }

        public LinearSearch(int[] vector, int numberToFind)
        {
            this.vector = vector;
            _numberToFind = numberToFind;
        }

        public void SetAttempts(int limit)
        {
            _attempts = limit;
        }

        public void SetNumberToFind(int numberToFind)
        {
            _numberToFind = numberToFind;
        }

        public int AlgorithmInstrumentation()
        {
            OpAssignment = OpComparisonLt = 1;
            for (int i = 0; i < vector.Length; i++, OpIncrement++)
            {
                OpComparisonEq++;
                if (vector[i] == _numberToFind) return i;
                OpComparisonLt++;
            }
            return -1;
        }

        public string GetInstrumentation()
        {
            return $"{OpAssignment}; {OpComparisonEq}; {OpComparisonLt}; {OpIncrement}";
        }

        public double AlgorithmSpeedTest()
        {
            long startTime = Stopwatch.GetTimestamp();

            for(var i = 0; i < _attempts; i++)
                LinearSearchAlgorithm();

            long stopTime = Stopwatch.GetTimestamp();

            return (stopTime - startTime) / (double)Stopwatch.Frequency;
        }

        public int LinearSearchAlgorithm()
        {
            foreach (int i in vector)
                if (i == _numberToFind)
                    return i;

            return -1;
        }
    }
}