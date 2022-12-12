using AoC.AdventOfCode.Common.IntCodeComputer.Base;
using AoC.AdventOfCode.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.IntCodeComputer.Instructions
{
    public class OpInput : BaseInstruction
    {
        #region Data
        private long input;

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

        protected override void DoLoadParameter(OpHelper opHelper)
        {
            input = opHelper.InputStack.First();
            opHelper.InputStack.RemoveFirst();
        }

        protected override void DoSaveResult(OpHelper opHelper)
        {
            PutParameterValue(1, input, opHelper);
        }

        #endregion
    }
}
