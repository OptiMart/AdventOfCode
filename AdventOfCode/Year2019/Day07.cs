using AoC.AdventOfCode.Base;
using AoC.IntcodeComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Year2019
{
    public class Day07 : PuzzleBase
    {
        #region Data
        private List<int> _settings;
        private List<List<int>> _allSettings;

        #endregion

        #region Constructor
        public Day07() : base(2019, 7)
        { }

        #endregion

        #region Methods
        public override void LoadAdditionalParameter(string[] args)
        {
            string strSettings = args[0] ?? string.Empty;
            var settings = strSettings.Split(',');

            _settings = new List<int>(settings.Length);

            foreach (var item in settings)
            {
                if (!int.TryParse(item, out int i))
                    throw new ArgumentException("Fehlerhafte Phase Settings");

                _settings.Add(i);
            }
        }

        protected override int SolvePuzzlePartOne()
        {
            LoadAdditionalParameter(new[] { "0,1,2,3,4" });
            int res = GetMaxThrusterSignal();
            Console.WriteLine($"{res}");
            return res;
        }

        protected override int SolvePuzzlePartTwo()
        {
            LoadAdditionalParameter(new[] { "5,6,7,8,9" });
            int res = GetMaxThrusterSignal();
            Console.WriteLine($"{res}");
            return res;
        }

        private int GetMaxThrusterSignal()
        {
            //Dictionary<List<int>, int> resultSet = new Dictionary<List<int>, int>();
            //List<int> result = new List<int>();
            int signalStrength = 0;

            foreach (var settings in GetPermutations(_settings, _settings.Count))
            {
                var output = GetThrusterSignal(settings);

                if (output > signalStrength)
                {
                    signalStrength = output;
                    //result = settings.ToList();
                }
            }

            //var result = resultSet.Min(x => x.Value);

            return signalStrength;
        }

        private IEnumerable<IEnumerable<T>>GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        private int GetThrusterSignal(IEnumerable<int> settings)
        {
            LinkedList<Computer> amplifier = new LinkedList<Computer>();

            foreach (var phase in settings)
            {
                var amp = new Computer(PuzzleInput);
                amp.LoadDefaultInstructionSet();

                if (amplifier.Count > 0)
                    amp.InputStack = amplifier.Last.Value.OutputStack;
                else
                    amp.InputStack.AddLast(0);
                
                amp.InputStack.AddFirst(phase);

                int opcode = amp.StartExecution();

                if (opcode != 99 && opcode != 3)
                    throw new InvalidProgramException($"Amplifier stoped with wrong Code");

                amplifier.AddLast(amp);
            }

            if (amplifier.Count >= 1)
                amplifier.First.Value.InputStack = amplifier.Last.Value.OutputStack;

            int minCode;
            do
            {
                minCode = 99;
                foreach (var amp in amplifier)
                {
                    int opcode = amp.StartExecution();

                    minCode = opcode < minCode ? opcode : minCode;
                }
            } while (minCode != 99);

            return amplifier.Last.Value.OutputStack.Count > 0 ? amplifier.Last.Value.OutputStack.Last() : 0;
        }

        #endregion
    }
}
