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
        private long output;

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

        protected override void DoLoadParameter(OpHelper opHelper)
        {
            output = GetParameterValue(1, opHelper);
        }

        protected override void DoSaveResult(OpHelper opHelper)
        {
            opHelper.OutputStack.AddLast(output);
        }

        #endregion
    }
}
