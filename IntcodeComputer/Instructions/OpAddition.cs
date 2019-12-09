using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer.Instructions
{
    public class OpAddition : BaseInstruction
    {
        #region Data
        private int op1;
        private int op2;
        private int result;

        #endregion
        
        #region Constructor
        public OpAddition() : base(1, 3)
        { }

        #endregion

        #region Methods
        protected override void DoCalculation()
        {
            result = op1 + op2;
        }

        protected override void DoLoadParameter(Memory memory, LinkedList<int> stack = null)
        {
            op1 = GetParameterMode(1) == ParameterMode.Imidiate ? GetParameter(1) : memory.GetFromAddress(GetParameter(1));
            op2 = GetParameterMode(2) == ParameterMode.Imidiate ? GetParameter(2) : memory.GetFromAddress(GetParameter(2));
        }

        protected override void DoSaveResult(Memory memory, LinkedList<int> stack = null)
        {
            PutParameter(memory, 3, result);
        }

        #endregion
    }
}
