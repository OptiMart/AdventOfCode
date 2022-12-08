using AoC.AdventOfCode.Common;
using AoC.AdventOfCode.Connector;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aoc.AdventOfCode
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] start = new int[] { 0, 0, 0 };

            for (int i = 0; i < args.Length; i++)
                int.TryParse(args[i], out start[i]);

            start[0] = 2022;
            start[1] = 8;
            start[2] = 0;

            try
            {
                SolveAllPuzzles(start[0], start[1], start[2]);
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler");
            }

            //Connector connector = new Connector(_webSession);
            //Console.Write(connector.SubmitPuzzleAnswer(2022, 4, 1, "599"));

            //connector.SavePuzzleInput(0,0);

            Console.ReadKey();
        }

        private static void SolveAllPuzzles(int year = 0, int day = 0, int part = 0)
        {
            var puzzles = PuzzleHelper.GetPuzzles(year, day);

            foreach (var puzzle in puzzles.OrderBy(x => x.Year * 100 + x.Day))
                puzzle.SolvePuzzle(part);

        }

        static string GetSessionID()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings["SessionID"] ?? string.Empty;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }

            return string.Empty;
        }
    }
}

