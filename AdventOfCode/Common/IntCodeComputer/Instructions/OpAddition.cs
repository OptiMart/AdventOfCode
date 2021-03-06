﻿using AoC.AdventOfCode.Common.IntCodeComputer.Base;
using AoC.AdventOfCode.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.IntCodeComputer.Instructions
{
    public class OpAddition : BaseInstruction
    {
        #region Data
        private long op1;
        private long op2;
        private long result;

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
