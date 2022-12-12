using AoC.AdventOfCode.Common.IntCodeComputer.Base;
using AoC.AdventOfCode.Common.IntCodeComputer.Instructions;
using AoC.AdventOfCode.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.IntCodeComputer
{
    public class Computer
    {
        #region Data
        private readonly List<IInstructions> _instructions = new List<IInstructions>();
        private long _relBase = 0;
        private readonly InstructionPointer _pointer = new InstructionPointer();

        #endregion

        #region Constructor
        public Computer() : this(new Memory())
        { }

        public Computer(string memory) : this(new Memory(memory))
        { }

        public Computer(Memory memory)
        {
            Memory = memory;
        }

        #endregion

        #region Properties
        public OpHelper OpHelper { get; private set; }
        public Memory Memory { get; private set; }
        public LinkedList<long> InputStack { get; set; } = new LinkedList<long>();
        public LinkedList<long> OutputStack { get; set; } = new LinkedList<long>();
        public int LastExitCode { get; private set; } = -1;
        public int Position => _pointer.Position;
        public int Address { get; set; }

        #endregion

        #region Methods
        public void Initialize()
        {
            if (Memory is null)
                Memory = new Memory();

            Memory.LoadInitialMemory();

            _relBase = 0;

            _pointer.Position = 0;

            InputStack.Clear();
            OutputStack.Clear();

            LastExitCode = -1;
        }

        public void LoadMemory(string memory, char separator = ',')
        {
            Memory.LoadMemory(memory, separator);
        }

        public void LoadInputStack(string stack, char separator = ',')
        {
            InputStack.Clear();
            AddToInputStack(stack, separator);
        }

        private void InitOpHelper()
        {
            OpHelper = new OpHelper()
            {
                Memory = Memory,
                InputStack = InputStack,
                OutputStack = OutputStack,
                InstructionPointer = _pointer,
                RelativeBase = _relBase,
            };
        }

        public void AddToInputStack(string stack, char separator = ',')
        {
            var inArr = stack.Split(separator);

            foreach (var item in inArr.Reverse())
            {
                if (!int.TryParse(item, out int val))
                    throw new InvalidOperationException($"Fehlerhafter input string an Position: {item}");

                InputStack.AddLast(val);
            }
        }

        public void LoadInstruction(IInstructions instruction)
        {
            if (_instructions.Any(x => x.OPCode == instruction.OPCode))
                throw new InvalidOperationException($"Instruction mit OPCode {instruction.OPCode} bereits geladen");

            _instructions.Add(instruction);
        }

        public void ClearInstructions()
        {
            _instructions.Clear();
        }

        public void RemoveInstruction(IInstructions instruction)
        {
            var instr = _instructions.FirstOrDefault(x => x.OPCode == instruction.OPCode);

            if (instr is null)
                throw new InvalidOperationException($"Instruction mit OPCode {instruction.OPCode} nicht gefunden");

            _instructions.Remove(instr);
        }

        public void LoadDefaultInstructionSet()
        {
            foreach (var item in ReflectiveEnumerator.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(BaseInstruction)))
            {
                LoadInstruction((BaseInstruction)Activator.CreateInstance(item));
            }
        }

        public int StartExecution()
        {
            try
            {
                InitOpHelper();
                
                while (LastExitCode != 99)
                {
                    var op = _instructions.FirstOrDefault(x => x.CheckInstruction(Memory, Position)); if (op is null)
                        throw new InvalidOperationException($"Ungültige Operation an Position: {Position}");

                    if (op.OPCode == 3 && InputStack.Count <= 0)
                    {
                        LastExitCode = 3;
                        _relBase = OpHelper.RelativeBase;
                        return 3;
                    }

                    LastExitCode = op.ExecuteInstruction(OpHelper);
                }
                _relBase = OpHelper.RelativeBase;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Fehler bei der Ausführung", ex);
            }

            return LastExitCode;
        }

        public Task<int> StartExecutionAsync()
        {
            Task<int> task = new Task<int>(() =>
            {
                while (LastExitCode != 99)
                {
                    if (LastExitCode == 3 && InputStack.Count == 0)
                        PushInput(-1);

                    StartExecution();
                }

                return LastExitCode;
            });

            return task;
        }

        public long? PopOutput()
        {
            if (OutputStack.Count == 0)
                return null;

            var result = OutputStack.First();
            OutputStack.RemoveFirst();

            return result;
        }

        public void PushInput(long input, bool startExecution = false)
        {
            InputStack.AddLast(input);
            if (startExecution && LastExitCode == 3)
                StartExecution();
        }

        public string GetAsciiOutput()
        {
            StringBuilder result = new StringBuilder();

            while (OutputStack.Count > 0)
            {
                result.Append((char)PopOutput());
            }

            return result.ToString();
        }

        public void WriteAsciiInput(string input, bool startExecution = true)
        {
            if (string.IsNullOrEmpty(input))
                return;

            foreach (var item in input)
            {
                PushInput((int)item);
            }

            if (startExecution)
                StartExecution();
        }

        #endregion
    }
}
