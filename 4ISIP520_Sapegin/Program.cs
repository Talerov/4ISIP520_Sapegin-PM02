using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ISIP520_Sapegin
{
    class Program
    {
        //Расчет опорного плана
        static (int[][], int) MinimumCostMethod(int[] supply, int[] demand, int[][] costs)
        {
            int[][] allocation = new int[supply.Length][];
            for (int i = 0; i < supply.Length; i++)
            {
                allocation[i] = new int[demand.Length];
            }

            int[] supplyCopy = supply.ToArray();
            int[] demandCopy = demand.ToArray();
            int totalCost = 0;

            while (true)
            {
                int minCost = int.MaxValue;
                int minRow = -1, minCol = -1;

                for (int row = 0; row < supply.Length; row++)
                {
                    for (int col = 0; col < demand.Length; col++)
                    {
                        if (supplyCopy[row] > 0 && demandCopy[col] > 0)
                        {
                            if (costs[row][col] < minCost)
                            {
                                minCost = costs[row][col];
                                minRow = row;
                                minCol = col;
                            }
                        }
                    }
                }

                if (minRow == -1 || minCol == -1)
                {
                    break;
                }

                int x = Math.Min(supplyCopy[minRow], demandCopy[minCol]);
                allocation[minRow][minCol] = x;
                supplyCopy[minRow] -= x;
                demandCopy[minCol] -= x;
                totalCost += x * minCost;
            }

            return (allocation, totalCost);
        }
        static void Main()
        {
            // Исходные данные
            int[] supply = { 20, 45, 24, 31, 30 };
            int[] demand = { 65, 44, 41 };
            int[][] costs = new int[][]
            {
            new int[] { 5, 4, 6, },
            new int[] { 7, 3, 3, },
            new int[] { 9, 5, 2 },
            new int[] { 3, 2, 5 },
            new int[] { 4, 7, 1 }
            };


            var (allocationMinCost, totalCostMinCost) = MinimumCostMethod(supply, demand, costs);

            foreach (var row in allocationMinCost)
            {
                Console.WriteLine(string.Join(", ", row));
            }
            Console.WriteLine("Total Cost: " + totalCostMinCost);
            Console.ReadKey();
        }
    }
}
