using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer.Base
{
    public class InstructionPointer
    {
        #region Data
        private int _position = 0;

        #endregion

        #region Constructor
        public InstructionPointer() : this(0)
        { }

        public InstructionPointer(int position)
        {
            Position = position;
        }

        #endregion

        #region Properties
        public int Position
        {
            get => _position;
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Instructionpointer kann nicht kleiner als 0 sein.");
                
                _position = value;
            }
        }

        #endregion

        #region Methods
        public void IncresePointer(int steps)
        {
            Position += steps;
        }

        #endregion
    }
}
