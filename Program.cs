using System;
using System.Collections.Generic;
using System.Linq;

namespace CellularAutomata
{
    class Program
    {
        static void Main(string[] args)
        {
            var generations = int.Parse(args[0]);
            var width = int.Parse(args[1]);
            var ruleNum = int.Parse(args[2]);
            var seedIndex = int.Parse(args[3]);
            var seed = Enumerable.Repeat(0, width).ToArray();
            seed[seedIndex] = 1;
            Console.WriteLine("Generating {0} generations {1} wide from rule {2} with seed {3}", generations, width, ruleNum, seedIndex);
            var cellularAutomata = new CellularAutomata(ruleNum, seed);

            PrintGeneration(seed);
            for (var generation = 0; generation < generations; generation++)
            {
                PrintGeneration(cellularAutomata.Next());
            }
        }
        static void PrintGeneration(int[] generation)
        {
            Console.WriteLine(string.Join("", generation));
        }
    }
}
