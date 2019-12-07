using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Geometry
{
    class Wire
    {
        #region Contructor
        public Wire()
        {

        }

        #endregion

        #region Properties
        public LinkedList<Line> Lines { get; private set; } = new LinkedList<Line>();

        #endregion
    }
}
