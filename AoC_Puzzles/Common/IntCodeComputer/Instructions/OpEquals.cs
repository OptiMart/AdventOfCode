using AoC.Puzzles.Common.IntCodeComputer.Base;
using AoC.Puzzles.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer.Instructions
{
    public class OpEquals : BaseInstruction
    {
        #region Data
        private long result;
        private long param1;
        private long param2;

        #endregion

        #region Constructor
        public OpEquals() : base(8, 3)
        { }

        #endregion

        #region Methods
        protected override void DoCalculation()
        {
            result = param1 == param2 ? 1 : 0;
        }

        protected override void DoLoadParameter(OpHelper opHelper)
        {
            param1 = GetParameterValue(1, opHelper);
            param2 = GetParameterValue(2, opHelper);
        }

        protected override void DoSaveResult(OpHelper opHelper)
        {
            PutParameterValue(3, result, opHelper);
        }

        #endregion
    }
}
