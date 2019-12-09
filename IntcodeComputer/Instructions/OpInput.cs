using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer.Instructions
{
    public class OpInput : BaseInstruction
    {
        #region Data
        private int input;

        #endregion

        #region Constructor
        public OpInput() : base(3, 1)
        { }

        #endregion

        #region Methods
        protected override void DoCalculation()
        {
            // No Calculation
        }

        protected override void DoLoadParameter(Memory memory, LinkedList<int> stack = null)
        {
            input = stack.First();
            stack.RemoveFirst();
        }

        protected override void DoSaveResult(Memory memory, LinkedList<int> stack = null)
        {
            PutParameter(memory, 1, input);
        }

        #endregion
    }
}
