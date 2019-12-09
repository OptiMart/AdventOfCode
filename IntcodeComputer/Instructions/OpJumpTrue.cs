using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer.Instructions
{
    public class OpJumpTrue : BaseInstruction
    {
        #region Data
        private int newPos;
        private int param1;
        private int param2;

        #endregion

        #region Constructor
        public OpJumpTrue() : base(5, 2)
        { }

        #endregion

        #region Methods
        public override int ExecuteInstruction(Memory memory, ref int index, LinkedList<int> inStack = null, LinkedList<int> outStack = null)
        {
            _ = base.ExecuteInstruction(memory, ref index, inStack, outStack);

            if (newPos >= 0)
                index = newPos;

            return OPCode;
        }
        protected override void DoCalculation()
        {
            if (param1 != 0)
                newPos = param2;
            else
                newPos = -1;
        }

        protected override void DoLoadParameter(Memory memory, LinkedList<int> stack = null)
        {
            param1 = GetParameterMode(1) == ParameterMode.Imidiate ? GetParameter(1) : memory.GetFromAddress(GetParameter(1));
            param2 = GetParameterMode(2) == ParameterMode.Imidiate ? GetParameter(2) : memory.GetFromAddress(GetParameter(2));
        }

        protected override void DoSaveResult(Memory memory, LinkedList<int> stack = null)
        {
            // Nothing to save
        }

        #endregion
    }
}
