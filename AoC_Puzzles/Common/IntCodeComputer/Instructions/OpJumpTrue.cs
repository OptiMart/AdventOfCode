using AoC.Puzzles.Common.IntCodeComputer.Base;
using AoC.Puzzles.Common.IntCodeComputer.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer.Instructions
{
    public class OpJumpTrue : BaseInstruction
    {
        #region Data
        private int newPos;
        private long param1;
        private long param2;

        #endregion

        #region Constructor
        public OpJumpTrue() : base(5, 2)
        { }

        #endregion

        #region Methods
        public override int ExecuteInstruction(OpHelper opHelper)
        {
            _ = base.ExecuteInstruction(opHelper);

            if (newPos >= 0)
                opHelper.InstructionPointer.Position = newPos;

            return OPCode;
        }

        protected override void DoCalculation()
        {
            if (param1 != 0)
                newPos = (int)param2;
            else
                newPos = -1;
        }

        protected override void DoLoadParameter(OpHelper opHelper)
        {
            param1 = GetParameterValue(1, opHelper);
            param2 = GetParameterValue(2, opHelper);
        }

        protected override void DoSaveResult(OpHelper opHelper)
        {
            // Nothing to save
        }

        #endregion
    }
}
