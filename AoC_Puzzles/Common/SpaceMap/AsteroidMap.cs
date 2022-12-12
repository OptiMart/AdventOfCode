using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.SpaceMap
{
    public class AsteroidMap
    {
        #region Constructor
        public AsteroidMap()
        {
        }

        #endregion

        #region Properties
        public List<Asteroid> Asteroids { get; private set; } = new List<Asteroid>();
        public Asteroid Station { get; private set; }

        #endregion

        #region Methods
        public void LoadAsteroids(string input)
        {
            int y = 0;

            foreach (var pos in input.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                for (int x = 0; x < pos.Length; x++)
                {
                    if (pos[x] == '#')
                    {
                        Asteroids.Add(new Asteroid(x, y));
                    }
                }
                y++;
            }

            UpdateDetectionCount();
        }

        private void UpdateDetectionCount()
        {
            foreach (var asteroid in Asteroids)
            {
                //asteroid.DetectedObjects = 0;
                asteroid.DetectedObjects.Clear();

                foreach (var target in Asteroids)
                {
                    if (target == asteroid)
                        continue;

                    bool foundBlocker = false;

                    foreach (var blocker in Asteroids)
                    {
                        if (foundBlocker || blocker == target || blocker == asteroid)
                            continue;
                        
                        foundBlocker = asteroid.BlocksLineOfSight(target, blocker);
                    }

                    if (!foundBlocker)
                        asteroid.DetectedObjects.Add(target);
                }
            }
            Station = Asteroids.Aggregate((x, y) => x.DetectedObjects.Count > y.DetectedObjects.Count ? x : y);
        }

        public int GetMaxDetectionValue()
        {
            return Station.DetectedObjects.Count;
        }

        public Asteroid GetBetAsteroid()
        {
            int i = 1;
            foreach (var item in Station.DetectedObjects.OrderBy(x => Station.GetAngle(x)))
            {
                if (i == 200)
                {
                    return item;
                }

                i++;
            }

            return Station;
        }

        #endregion
    }
}
