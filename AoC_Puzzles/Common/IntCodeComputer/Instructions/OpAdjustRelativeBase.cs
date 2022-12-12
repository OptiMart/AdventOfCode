using AoC.Puzzles.Common.IntCodeComputer.Base;
using AoC.Puzzles.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer.Instructions
{
    public class OpAdjustRelativeBase : BaseInstruction
    {
        #region Data
        private long relBase;
        private long add;

        #endregion

        #region Constructor
        public OpAdjustRelativeBase() : base(9, 1)
        { }

        #endregion

        #region Methods
        protected override void DoCalculation()
        {
            relBase += add;

            if (relBase < 0)
                throw new InvalidOperationException("RelativeBase kann nicht kleiner 0 sein");
        }

        protected override void DoLoadParameter(OpHelper opHelper)
        {
            add = GetParameterValue(1, opHelper);
        }

        protected override void DoSaveResult(OpHelper opHelper)
        {
            opHelper.RelativeBase = relBase;
        }

        #endregion
    }
}
