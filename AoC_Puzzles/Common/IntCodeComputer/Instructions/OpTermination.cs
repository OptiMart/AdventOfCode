using AoC.Puzzles.Common.IntCodeComputer.Base;
using AoC.Puzzles.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer.Instructions
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

        protected override void DoLoadParameter(OpHelper opHelper)
        {
            // No Parameters to load
        }

        protected override void DoSaveResult(OpHelper opHelper)
        {
            // No Result to be saved
        }
    }
}
