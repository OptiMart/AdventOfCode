using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer.Instructions
{
    public class OpOutput : BaseInstruction
    {
        #region Data
        private int output;

        #endregion

        #region Constructor
        public OpOutput() : base(4, 1)
        { }

        #endregion

        #region Methods
        protected override void DoCalculation()
        {
            // No Calculation
        }

        protected override void DoLoadParameter(Memory memory, Stack<int> stack = null)
        {
            output = GetParameterMode(1) == ParameterMode.Imidiate ? GetParameter(1) : memory.GetFromAddress(GetParameter(1));
        }

        protected override void DoSaveResult(Memory memory, Stack<int> stack = null)
        {
            stack.Push(output);
        }

        #endregion
    }
}
