using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.IntCodeComputer
{
    public class AsyncComputer : Computer
    {
        #region Methods
        public int StartExecutionAsync()
        {
            while (LastExitCode !=  99)
            {
                if (LastExitCode == 3 && InputStack.Count == 0)
                    PushInput(-1);

                StartExecution();
            }

            return LastExitCode;
        }

        #endregion
    }
}
