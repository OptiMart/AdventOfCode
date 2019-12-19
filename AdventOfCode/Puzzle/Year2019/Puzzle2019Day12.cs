using AoC.AdventOfCode.Common.SpaceMap;
using AoC.AdventOfCode.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Puzzle.Year2019
{
    public class Puzzle2019Day12 : PuzzleBase
    {
        #region Data
        private List<OrbitObject> moons;
        private List<OrbitObject> original;
        private int[] initPotEnergy;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            moons = new List<OrbitObject>();
            original = new List<OrbitObject>();

            foreach (var item in PuzzleInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                OrbitObject obj = new OrbitObject();
                
                foreach (var coord in item.TrimStart('<').TrimEnd('>').Split(','))
                {
                    var temp = coord.Split('=');
                    if (!int.TryParse(temp[1].Trim(), out int val))
                        continue;
                    
                    if (temp[0].Contains('x'))
                        obj.Position.X = val;
                    else if (temp[0].Contains('y'))
                        obj.Position.Y = val;
                    else if (temp[0].Contains('z'))
                        obj.Position.Z = val;
                }

                original.Add(obj);
            }

            initPotEnergy = new int[original.Count];
            for (int i = 0; i < original.Count; i++)
            {
                initPotEnergy[i] = original[i].Position.GetEnergy();
            }
        }

        private void ResetMoons()
        {
            moons = new List<OrbitObject>();
            foreach (var item in original)
            {
                OrbitObject oo = new OrbitObject();
                oo.Position.X = item.Position.X;
                oo.Position.Y = item.Position.Y;
                oo.Position.Z = item.Position.Z;

                moons.Add(oo);
            }
        }

        protected override long SolvePuzzlePartOne()
        {
            ResetMoons();

            for (int i = 0; i < 1000; i++)
            {
                CalcVelocity();

                foreach (var moon in moons)
                {
                    moon.UpdatePosition();
                }
            }

            var res = moons.Sum(m => m.GetTotalEnergy());
            Console.WriteLine($"{res}");
            return res;
        }

        protected override long SolvePuzzlePartTwo()
        {
            ResetMoons();

            int i = 0;
            int x = 0;
            int y = 0;
            int z = 0;

            do
            {
                i++;
                CalcVelocity();

                foreach (var moon in moons)
                {
                    moon.UpdatePosition();
                }

                if (x == 0 && CheckPositionX())
                    x = i;

                if (y == 0 && CheckPositionY())
                    y = i;

                if (z == 0 && CheckPositionZ())
                    z = i;

                //if (CheckOriginalPosition())
                //    break;

            } while (x == 0 || y == 0 || z == 0);

            var res = GetKgV(GetKgV(x, y), z);
            Console.WriteLine($"{res}");
            return 0;
        }

        private void CalcVelocity()
        {
            foreach (var moon in moons)
            {
                int relX = 0;
                int relY = 0;
                int relZ = 0;

                foreach (var rel in moons)
                {
                    if (moon == rel)
                        continue;

                    if (moon.Position.X < rel.Position.X)
                        relX++;
                    else if (moon.Position.X > rel.Position.X)
                        relX--;

                    if (moon.Position.Y < rel.Position.Y)
                        relY++;
                    else if (moon.Position.Y > rel.Position.Y)
                        relY--;

                    if (moon.Position.Z < rel.Position.Z)
                        relZ++;
                    else if (moon.Position.Z > rel.Position.Z)
                        relZ--;
                }

                moon.Velocity.X += relX;
                moon.Velocity.Y += relY;
                moon.Velocity.Z += relZ;
            }
        }

        private bool CheckPositionX()
        {
            int pos = 0;

            for (int i = 0; i < moons.Count; i++)
            {
                if (Check(original[i].Position.X, original[i].Velocity.X, moons[i].Position.X, moons[i].Velocity.X))
                    pos++;
            }

            return pos >= 4;
        }

        private bool CheckPositionY()
        {
            int pos = 0;

            for (int i = 0; i < moons.Count; i++)
            {
                if (Check(original[i].Position.Y, original[i].Velocity.Y, moons[i].Position.Y, moons[i].Velocity.Y))
                    pos++;
            }

            return pos >= 4;
        }

        private bool CheckPositionZ()
        {
            int pos = 0;

            for (int i = 0; i < moons.Count; i++)
            {
                if (Check(original[i].Position.Z, original[i].Velocity.Z, moons[i].Position.Z, moons[i].Velocity.Z))
                    pos++;
            }

            return pos >= 4;
        }

        private bool CheckOriginalPosition()
        {
            for (int i = 0; i < moons.Count; i++)
            {
                if (!moons[i].Equals(original[i]))
                    return false;
            }

            return true;
        }

        private bool Check(int p0, int v0, int p, int v)
        {
            return p0 == p && v0 == v;
        }

        public long GetGgT(long m, long n)
        {
            if (n == 0)
                return m;
            else
                return GetGgT(n, m % n);
            
            long zahl1 = m;
            long zahl2 = n;
            //Diese Variable wird bei Wertzuweisungen zwischen den Zahlen benutzt
            long temp = 0;
            //Der Rückgabewert zweier gegebener Zahlen.
            long ggt = 0;//Solange der Modulo der zwei zahlen nicht 0 ist,
                        //werden Zuweisungen entsprechend demEuklidischen Algorithmus ausgeführt.
            while (zahl1 % zahl2 != 0)
            {
                temp = zahl1 % zahl2;
                zahl1 = zahl2;
                zahl2 = temp;
            }

            ggt = zahl2;

            return ggt;

        }

        public long GetKgV(long m, long n)
        {
            return (m * n) / GetGgT(m, n);
        }
        #endregion
    }
}
