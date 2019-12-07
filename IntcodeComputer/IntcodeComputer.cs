using AoC.IntcodeComputer.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer
{
    public class IntcodeComputer
    {
        #region Data
        private readonly List<IInstructions> _instructions = new List<IInstructions>();
        private readonly Stack<int> _stack;
        private int _pointer = 0;

        #endregion

        #region Constructor
        public IntcodeComputer() : this(new Memory())
        { }

        public IntcodeComputer(string memory) : this(new Memory(memory))
        { }

        public IntcodeComputer(Memory memory)
        {
            Memory = memory;
        }

        #endregion

        #region Properties
        public Memory Memory { get; private set; }

        #endregion

        #region Methods
        public void LoadMemory(string memory, char separator = ',')
        {
            Memory.LoadMemory(memory, separator);
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
        }


        #endregion
    }
}
