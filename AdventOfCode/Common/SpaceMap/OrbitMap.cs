using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.SpaceMap
{
    public class OrbitMap
    {
        #region Constructor
        public OrbitMap()
        {

        }

        #endregion

        #region Properties
        public OrbitObject CoM { get; private set; }
        public OrbitObject You { get; private set; }
        public OrbitObject San { get; private set; }
        public List<OrbitObject> AllOrbitObjects { get; private set; } = new List<OrbitObject>();

        #endregion

        #region Methods
        public void LoadOrbitalMap(string input)
        {
            var links = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var link in links)
            {
                var objects = link.Split(')');

                var obj1 = CheckOrAddOrbitObject(objects[0]);
                var obj2 = CheckOrAddOrbitObject(objects[1]);

                obj1.Children.Add(obj2);
                obj2.Parent = obj1;
            }
        }

        private OrbitObject CheckOrAddOrbitObject(string name)
        {
            var obj = AllOrbitObjects.FirstOrDefault(x => x.Name == name);

            if (obj != null)
                return obj;

            obj = new OrbitObject(name);
            AllOrbitObjects.Add(obj);
            CheckSetSpecials(obj);
            return obj;
        }

        private void CheckSetSpecials(OrbitObject obj)
        {
            if (CoM is null && obj.Name == "COM")
                CoM = obj;
            if (You is null && obj.Name == "YOU")
                You = obj;
            if (San is null && obj.Name == "SAN")
                San = obj;
        }

        public int CalcAllOrbits()
        {
            int count = 0;

            foreach (var item in AllOrbitObjects)
            {
                count += item.CoMDistance;
            }

            return count;
        }

        public int CalcSantaDistance()
        {
            var anchestor = GetSameAnchestor(You, San);

            int distYou = You.Parent.CoMDistance - anchestor.CoMDistance;
            int distSan = San.Parent.CoMDistance - anchestor.CoMDistance;

            return distYou + distSan;
        }

        private OrbitObject GetSameAnchestor(OrbitObject obj1, OrbitObject obj2)
        {
            OrbitObject anchestor1 = obj1;
            OrbitObject anchestor2;
            do
            {
                anchestor1 = anchestor1.Parent;
                anchestor2 = obj2;
                do
                {
                    anchestor2 = anchestor2.Parent;
                } while (anchestor2.Parent != null && anchestor1 != anchestor2);
            } while (anchestor1.Parent != null && anchestor1 != anchestor2);

            if (anchestor1 == anchestor2)
            {
                return anchestor1;
            }

            return null;
        }

        #endregion
    }
}
