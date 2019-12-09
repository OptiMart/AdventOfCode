using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.OrbitMap
{
    public class OrbitObject
    {
        #region Constructor
        public OrbitObject(string name)
        {
            Name = name;
        }

        #endregion

        #region Properties
        public string Name { get; private set; }
        public List<OrbitObject> Children { get; private set; } = new List<OrbitObject>();
        public OrbitObject Parent { get; set; }
        public int CoMDistance => Parent is null ? 0 : Parent.CoMDistance + 1;

        #endregion
    }
}
