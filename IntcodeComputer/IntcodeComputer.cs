using AoC.IntcodeComputer.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer
{
    public class Computer
    {
        #region Data
        private readonly List<IInstructions> _instructions = new List<IInstructions>();
        private int _position = 0;

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
        public Memory Memory { get; private set; }
        public LinkedList<int> InputStack { get; set; } = new LinkedList<int>();
        public LinkedList<int> OutputStack { get; set; } = new LinkedList<int>();
        public int LastExitCode { get; private set; } = -1;

        #endregion

        #region Methods
        public void LoadMemory(string memory, char separator = ',')
        {
            Memory.LoadMemory(memory, separator);
        }

        public void LoadInputStack(string stack, char separator = ',')
        {
            InputStack.Clear();
            AddToInputStack(stack, separator);
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
            var instr =_instructions.FirstOrDefault(x => x.OPCode == instruction.OPCode);

            if (instr is null)
                throw new InvalidOperationException($"Instruction mit OPCode {instruction.OPCode} nicht gefunden");

            _instructions.Remove(instr);
        }

        public void LoadDefaultInstructionSet()
        {
            LoadInstruction(new OpTermination());
            LoadInstruction(new OpAddition());
            LoadInstruction(new OpMultiplication());
            LoadInstruction(new OpInput());
            LoadInstruction(new OpOutput());
            LoadInstruction(new OpJumpTrue());
            LoadInstruction(new OpJumpFalse());
            LoadInstruction(new OpLessThan());
            LoadInstruction(new OpEquals());
        }

        public int StartExecution()
        {
            try
            {
                while (LastExitCode != 99)
                {
                    var op = _instructions.FirstOrDefault(x => x.CheckInstruction(Memory, _position));

                    if (op is null)
                        throw new InvalidOperationException($"Ungültige Operation an Position: {_position}");

                    if (op.OPCode == 3 && InputStack.Count <= 0)
                    {
                        LastExitCode = 3;
                        return 3;
                    }

                    LastExitCode = op.ExecuteInstruction(Memory, ref _position, InputStack, OutputStack);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Fehler bei der Ausführung", ex);
            }

            return LastExitCode;
        }

        #endregion
    }
}
