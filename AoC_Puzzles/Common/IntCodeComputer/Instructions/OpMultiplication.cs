using AoC.Puzzles.Common.IntCodeComputer.Base;
using AoC.Puzzles.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer.Instructions
{
    public class OpMultiplication : BaseInstruction
    {
        #region Data
        private long op1;
        private long op2;
        private long result;

        #endregion
        
        #region Constructor
        public OpMultiplication() : base(2, 3)
        { }

        #endregion

        #region Methods
        protected override void DoCalculation()
        {
            result = op1 * op2;
        }

        protected override void DoLoadParameter(OpHelper opHelper)
        {
            op1 = GetParameterValue(1, opHelper);
            op2 = GetParameterValue(2, opHelper);
        }

        protected override void DoSaveResult(OpHelper opHelper)
        {
            PutParameterValue(3, result, opHelper);
        }

        #endregion
    }
}
