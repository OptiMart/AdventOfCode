using AoC.AdventOfCode.Common.IntCodeComputer.Base;
using AoC.AdventOfCode.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.IntCodeComputer.Instructions
{
    public class OpLessThan : BaseInstruction
    {
        #region Data
        private int result;
        private long param1;
        private long param2;

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
