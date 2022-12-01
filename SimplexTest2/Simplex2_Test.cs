using NUnit.Framework;
using System;

namespace SimplexTest1
{
    public class UnitTests
    {
        [Test]
        public void GetTheCorrectCalculation()
        {
            double[,] table = { {20, 2,  8},
                                {10, -4,  4},
                                {30,  6,  6},
                                { 0, -4, -7} };

            double[] variables = new double[3];
            SimplexNamespace.Simplex S = new SimplexNamespace.Simplex(table);

            double[,] expected_result = { {1.67, 0, 1, 0.16, 0, -0.06},
                                          {16.65, 0, 0, -1.28, 1, 1.1},
                                          {3.33, 1, 0, -0.16, 0, 0.22},
                                          {24.99, 0, 0, 0.48, 0, 0.5} };

            double[,] real_result = S.Calculate(variables);
            Assert.AreEqual(expected_result, real_result);
        }

        [Test]
        public void GetTheWrongCalculation()
        {
            double[,] table = { {50, 2,  6},
                                {10, -1,  4},
                                {30,  6,  4},
                                { 0, -1, -2} };

            double[] variables = new double[3];
            SimplexNamespace.Simplex S = new SimplexNamespace.Simplex(table);

            double[,] expected_result = { {1, 0, 1, 0.32, 0, -0.1},
                                          {12.65, 0, 0.21, -1.63, 1, 1.1},
                                          {1.33, 1, 0, -0.16, 0, 0.22},
                                          {14.99, 0, 1, 0.48, 1, 0.57} };

            double[,] real_result = S.Calculate(variables);
            Assert.AreNotEqual(expected_result, real_result);
        }

        //[Test]
        //public void GetTheCorrectCount()
        //{
        //    int expected_result = 3;
        //    int real_result = MainNamespace.MainFunction.GetCount(3);

        //    Assert.AreEqual(expected_result, real_result);
        //}
    }

    public class IntegrationTests : MainNamespace.Inherit
    {
        [Test]
        public void GetTheCorrectObjectiveFunction()
        {
            double[,] table = { {25, -3,  5},
                                {30, -2,  5},
                                {10,  1,  0},
                                { 0, -6, -5} };

            double[] variables = new double[3];
            SimplexNamespace.Simplex S = new SimplexNamespace.Simplex(table);
            double[,] table_result = S.Calculate(variables);
            MainNamespace.MainFunction.GetTheObjectiveFunction(table_result);

            double real_result = Math.Round(table_result[0, 0], 2);
            double expected_result = 5;
            Assert.AreEqual(expected_result, real_result);
        }

        [Test]
        public void GetTheWrongObjectiveFunction()
        {
            double[,] table = { {55, 3,  5},
                                {80, 8,  -5},
                                {110,  1,  0},
                                { 0, -2, -4} };

            double[] variables = new double[3];
            SimplexNamespace.Simplex S = new SimplexNamespace.Simplex(table);
            double[,] table_result = S.Calculate(variables);
            MainNamespace.MainFunction.GetTheObjectiveFunction(table_result);

            double real_result = Math.Round(table_result[0, 0], 2);
            double expected_result = 5;
            Assert.AreNotEqual(expected_result, real_result);
        }

        [Test]
        public void GetTheCorrectSolution()
        {
            double[,] table = { {50, 5,  2},
                                {30, 5,  8},
                                {40, 3,  1},
                                {0, -2, -4} };

            double[] variables = new double[3];
            SimplexNamespace.Simplex S = new SimplexNamespace.Simplex(table);
            S.Calculate(variables);
            MainNamespace.MainFunction.GetTheSolution(variables);

            double[] real_result = new double[variables.Length];
            for (int v = 0; v < variables.Length; v++)
            {
                real_result[v] = Math.Round(variables[v], 2);
            }
            double[] expected_result = { 0, 3.75, 42.5 };
            Assert.AreEqual(expected_result, real_result);
        }

        [Test]
        public void GetTheWrongSolution()
        {
            double[,] table = { {50, 5,  2},
                                {30, 5,  8},
                                {40, 3,  1},
                                {0, -2, -4} };

            double[] variables = new double[3];
            SimplexNamespace.Simplex S = new SimplexNamespace.Simplex(table);
            S.Calculate(variables);
            MainNamespace.MainFunction.GetTheSolution(variables);

            double[] real_result = new double[variables.Length];
            for (int v = 0; v < variables.Length; v++)
            {
                real_result[v] = Math.Round(variables[v], 2);
            }
            double[] expected_result = { 3, 0.75, 4.5 };
            Assert.AreNotEqual(expected_result, real_result);
        }

        [Test]
        public void GetTheCorrectSimplexTable()
        {
            double[,] table = { { 30, -1,  5},
                                { 15, -4,  6},
                                {  8,  1,  5},
                                {  0, -2, -3} };

            double[] variables = new double[3];
            SimplexNamespace.Simplex S = new SimplexNamespace.Simplex(table);
            double[,] table_result = S.Calculate(variables);
            MainNamespace.MainFunction.GetTheSimplexTable(table_result);

            double[,] real_result = new double[variables.Length + 1, variables.Length + 3];
            for (int i = 0; i < table_result.GetLength(0); i++)
            {
                for (int j = 0; j < table_result.GetLength(1); j++)
                    real_result[i, j] = Math.Round(table_result[i, j], 2);
            }
            double[,] expected_result = { {38, 0, 10, 1, 0, 1},
                                          {47, 0, 26, 0, 1, 4},
                                           {8, 1,  5, 0, 0, 1},
                                          {16, 0,  7, 0, 0, 2} };
            Assert.AreEqual(expected_result, real_result);
        }

        [Test]
        public void GetTheWrongSimplexTable()
        {
            double[,] table = { { 90, 0,  5},
                                { 30, -1,  6},
                                {  3,  2,  0},
                                {  0, -4, -3} };

            double[] variables = new double[3];
            SimplexNamespace.Simplex S = new SimplexNamespace.Simplex(table);
            double[,] table_result = S.Calculate(variables);
            MainNamespace.MainFunction.GetTheSimplexTable(table_result);

            double[,] real_result = new double[variables.Length + 1, variables.Length + 3];
            for (int i = 0; i < table_result.GetLength(0); i++)
            {
                for (int j = 0; j < table_result.GetLength(1); j++)
                    real_result[i, j] = Math.Round(table_result[i, j], 2);
            }
            double[,] expected_result = { {38, 0, 10, 1, 0, 1},
                                          {47, 0, 26, 0, 1, 4},
                                           {8, 1,  5, 0, 0, 1},
                                          {16, 0,  7, 0, 0, 2} };
            Assert.AreNotEqual(expected_result, real_result);
        }
    }
}