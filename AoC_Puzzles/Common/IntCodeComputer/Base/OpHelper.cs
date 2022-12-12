using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer.Base
{
    public class OpHelper
    {
        public Memory Memory { get; set; }
        public InstructionPointer InstructionPointer { get; set; }
        public LinkedList<long> InputStack { get; set; }
        public LinkedList<long> OutputStack { get; set; }
        public long RelativeBase { get; set; }
    }
}
