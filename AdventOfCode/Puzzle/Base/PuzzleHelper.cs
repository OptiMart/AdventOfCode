using AoC.AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC.AdventOfCode.Puzzle.Base
{
    public class PuzzleHelper
    {
        #region Constructor
        public PuzzleHelper()
        {

        }

        #endregion

        #region Properties
        public string SessionID { get; set; }
        public string FilePath { get; set; }

        #endregion

        #region Methods
        public virtual void LoadPuzzleInputFromFile(PuzzleBase puzzle, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
            {
                Connector.Connector connector = new Connector.Connector(SessionID);
                connector.SavePuzzleInput(puzzle.Year, puzzle.Day);
                fileInfo.Refresh();
            }
            if (fileInfo.Exists)
                puzzle.PuzzleInput = File.ReadAllText(filePath);
            else
                throw new FileNotFoundException($"Datei {filePath} konnte nicht gefunden werden");
        }

        public string GetInputPath(PuzzleBase puzzle, int part = 0)
        {
            return Path.Combine(FilePath, $@"{puzzle.Year:0000}\Input_Day{puzzle.Day:00}" + (part == 0 ? "" : $"_{part}") + ".txt");
        }

        public static List<PuzzleBase> GetPuzzles(int year = 0, int day = 0)
        {
            List<PuzzleBase> puzzles = new List<PuzzleBase>();

            foreach (var item in ReflectiveEnumerator.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(PuzzleBase)))
            {
                if ((year == 0 || year == PuzzleBase.GetYear(item)) && (day == 0 || day == PuzzleBase.GetDay(item)) && PuzzleBase.GetYear(item) != 0 && PuzzleBase.GetDay(item) != 0)
                    puzzles.Add((PuzzleBase)Activator.CreateInstance(item));
            }

            return puzzles;
        }

        public static PuzzleBase GetPuzzle(int year, int day)
        {
            return GetPuzzles(year, day).OrderBy(x => x.Year * 100 + x.Day).FirstOrDefault();
        }

        #endregion
    }
}
