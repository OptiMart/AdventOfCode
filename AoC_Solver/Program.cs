
using AoC.AdventOfCode.Puzzle.Base;

namespace AoC.Solver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadArgs(args, out int year, out int day, out int part);

#if DEBUG
            year = 2022;
            day = 12;
#endif

            try
            {
                SolvePuzzles(year, day, part);
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

        private static void ReadArgs(string[] args, out int year, out int day, out int part)
        {
            if (!(args.Length >= 1 && int.TryParse(args[0], out year))) { year = 0; }
            if (!(args.Length >= 2 && int.TryParse(args[1], out day))) { day = 0; }
            if (!(args.Length >= 3 && int.TryParse(args[2], out part))) { part = 0; }
        }

        private static void SolvePuzzles(int year = 0, int day = 0, int part = 0)
        {
            var puzzles = PuzzleHelper.GetPuzzles(year, day);

            foreach (var puzzle in puzzles.OrderBy(x => x.Year * 100 + x.Day))
                puzzle.SolvePuzzle(part);

        }

        //static string GetSessionID()
        //{
        //    try
        //    {
        //        var appSettings = ConfigurationManager.AppSettings;
        //        return appSettings["SessionID"] ?? string.Empty;
        //    }
        //    catch (ConfigurationErrorsException)
        //    {
        //        Console.WriteLine("Error reading app settings");
        //    }

        //    return string.Empty;
        //}
    }
}