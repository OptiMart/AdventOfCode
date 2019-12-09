using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer.Instructions
{
    public class OpLessThan : BaseInstruction
    {
        #region Data
        private int result;
        private int param1;
        private int param2;

        #endregion

        #region Constructor
        public OpLessThan() : base(7, 3)
        { }

        #endregion

        #region Methods
        protected override void DoCalculation()
        {
            result = param1 < param2 ? 1 : 0;
        }

        protected override void DoLoadParameter(Memory memory, LinkedList<int> stack = null)
        {
            param1 = GetParameterMode(1) == ParameterMode.Imidiate ? GetParameter(1) : memory.GetFromAddress(GetParameter(1));
            param2 = GetParameterMode(2) == ParameterMode.Imidiate ? GetParameter(2) : memory.GetFromAddress(GetParameter(2));
        }

        protected override void DoSaveResult(Memory memory, LinkedList<int> stack = null)
        {
            PutParameter(memory, 3, result);
        }

        #endregion
    }
}
