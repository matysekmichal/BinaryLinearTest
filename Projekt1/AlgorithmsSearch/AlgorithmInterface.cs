﻿namespace Projekt1.AlgorithmsSearch
{
    public interface IAlgorithm
    {
        int AlgorithmInstrumentation();
        double AlgorithmSpeedTest();
        string GetInstrumentation();
        void SetNumberToFind(int numberToFind);
    }
}