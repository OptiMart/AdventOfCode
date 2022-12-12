using AoC.AdventOfCode.Common.IntCodeComputer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.IntCodeComputer.Instructions.Base
{
    public interface IInstructions
    {
        int OPCode { get; }
        int ParameterCount { get; }

        bool CheckInstruction(long code);
        bool CheckInstruction(Memory memory, int index);
        int ExecuteInstruction(OpHelper opHelper);
    }
}
