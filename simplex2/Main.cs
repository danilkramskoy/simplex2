using SimplexNamespace;
namespace MainNamespace
{
    public class MainFunction : Inherit
    {
        public int count;
        public void Prog()
        {
            double[,] table = { {100, 15,  8},
                                {50, 5,  4},
                                {25,  2,  6},
                                { 0, -2, -3} };

            double[] variables = new double[GetCount(3)];
            Simplex S = new Simplex(table);
            double[,] table_result = S.Calculate(variables);
            GetTheSimplexTable(table_result);
            Console.WriteLine();
            GetTheSolution(variables);
            GetTheObjectiveFunction(table_result);
            Console.ReadLine();
        }
    }

    public class Inherit
    {
        protected static double[,] GetTheSimplexTable(double[,] table_result)
        {
            Console.WriteLine("Составленная симплекс-таблица:");
            for (int i = 0; i < table_result.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < table_result.GetLength(1); j++)
                    Console.Write(Math.Round(table_result[i, j], 2) + "\t");
                Console.WriteLine();
            }
            return table_result;
        }

        protected static double[] GetTheSolution(double[] variables)
        {
            Console.WriteLine("Получившееся решение:");
            for (int v = 0; v < variables.Length; v++)
            {
                Console.WriteLine("X{0} = {1}", v + 1, Math.Round(variables[v], 2));
            }
            return variables;
        }

        protected static double[,] GetTheObjectiveFunction(double[,] table_result)
        {
            Console.WriteLine("F = {0}", Math.Round(table_result[0, 0], 2));
            return table_result;
        }

        protected static int GetCount(int count)
        {
            return count;
        }
    }
}
