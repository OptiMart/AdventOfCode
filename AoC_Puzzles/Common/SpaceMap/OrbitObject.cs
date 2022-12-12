using AoC.AdventOfCode.Common.SpaceMap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.SpaceMap
{
    [DebuggerDisplay("{Name} <{Position.X}, {Position.Y}, {Position.Z}> <{Velocity.X}, {Velocity.Y}, {Velocity.Z}>")]
    public class OrbitObject
    {
        #region Constructor
        public OrbitObject()
        { }

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
        public SpaceVector Position { get; private set; } = new SpaceVector();
        public SpaceVector Velocity { get; private set; } = new SpaceVector();

        #endregion

        public void UpdatePosition()
        {
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
        }

        public int GetTotalEnergy()
        {
            return Position.GetEnergy() * Velocity.GetEnergy();
        }

        public override bool Equals(object obj)
        {
            OrbitObject oo = obj as OrbitObject;

            if (oo is null)
                return false;
            else
                return Position.Equals(oo.Position) && Velocity.Equals(oo.Velocity);
        }
    }
}
