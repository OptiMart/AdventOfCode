using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer.Instructions
{
    public class OpTermination : BaseInstruction
    {
        #region Constructor
        public OpTermination() : base(99, 0)
        { }

        #endregion
        protected override void DoCalculation()
        {
            // No Calculation
        }

        protected override void DoLoadParameter(Memory memory, Stack<int> stack = null)
        {
            // No Parameters to load
        }

        protected override void DoSaveResult(Memory memory, Stack<int> stack = null)
        {
            // No Result to be saved
        }
    }
}
