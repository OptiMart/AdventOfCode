using AoC.Puzzles.Common.Base;
using AoC.Puzzles.Common.Base.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common
{
    public class Biotop
    {
        #region Constructor
        public Biotop()
        {

        }

        #endregion

        #region Properties
        public UniversalMesh<BasePoint2D<bool>> Pond { get; private set; }

        #endregion

        #region Methods
        public void Initialize()
        {
            for (int i = 0; i < 25; i++)
            {
                Pond.AddNode(new BasePoint2D<bool>(false, i % 5, i / 5));
            }
        }

        #endregion
    }
}
