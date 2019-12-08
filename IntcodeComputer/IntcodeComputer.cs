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
            Stack = new Stack<int>();
        }

        #endregion

        #region Properties
        public Memory Memory { get; private set; }
        public Stack<int> Stack { get; private set; }

        #endregion

        #region Methods
        public void LoadMemory(string memory, char separator = ',')
        {
            Memory.LoadMemory(memory, separator);
        }

        public void LoadStack(string stack, char separator = ',')
        {
            Stack.Clear();
            AddToStack(stack, separator);
        }

        public void AddToStack(string stack, char separator = ',')
        {
            var inArr = stack.Split(separator);

            foreach (var item in inArr.Reverse())
            {
                if (!int.TryParse(item, out int val))
                    throw new InvalidOperationException($"Fehlerhafter input string an Position: {item}");

                Stack.Push(val);
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
            int result = -1;
            try
            {
                do
                {
                    var op = _instructions.FirstOrDefault(x => x.CheckInstruction(Memory, _position));

                    if (op is null)
                        throw new InvalidOperationException($"Ungültige Operation an Position: {_position}");

                    result = op.ExecuteInstruction(Memory, ref _position, Stack);
                } while (result != 99);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Fehler bei der Ausführung", ex);
            }

            return result;
        }
        #endregion
    }
}
