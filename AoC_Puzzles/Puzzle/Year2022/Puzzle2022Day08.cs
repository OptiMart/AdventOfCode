using AoC.Puzzles.Common.Base;
using AoC.Puzzles.Common.Base.Points;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Treetop Tree House
    /// </summary>
    public class Puzzle2022Day08 : PuzzleBase
    {
        #region Data
        //UniversalMesh<BasePoint2D<int>> forest = new UniversalMesh<BasePoint2D<int>>();
        int[,] forest;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();
            PuzzleItems = LoadPuzzleItemsString("\n", true);

            forest = new int[PuzzleItems.Count, PuzzleItems[0].Length];

            for (int row = 0; row < PuzzleItems.Count; row++)
            {
                for (int col = 0; col < PuzzleItems[row].Length; col++)
                {
                    if (int.TryParse(PuzzleItems[row][col].ToString(), out int height))
                    {
                        forest[row, col] = height;
                        //BasePoint2D<int> tree = new BasePoint2D<int>(height, row, col);
                        //forest.AddNode(tree);
                    }
                }
            }
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = (forest.GetLength(0) - 1) * 2 + (forest.GetLength(1) - 1) * 2;

            for (int row = 1; row < forest.GetLength(0) - 1; row++)
            {
                long rowCount = 0;
                for (int col = 1; col < forest.GetLength(1) - 1; col++)
                {
                    rowCount += CheckIsVisibleFromEdge(row, col);
                }
                result += rowCount;
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    long view = GetScenicScore(row, col);
                    result = view > result ? view : result;
                }
            }

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        private long GetScenicScore(int row, int col)
        {
            int[] dist = new int[4];

            // Check distance west
            for (int w = col - 1; w >= 0; w--)
            {
                dist[0]++;
                if (forest[row, col] <= forest[row, w])
                {
                    break;
                }
            }

            // Check distance east
            for (int e = col + 1; e <= forest.GetLength(1) - 1; e++)
            {
                dist[1]++;
                if (forest[row, col] <= forest[row, e])
                {
                    break;
                }
            }

            // Check distance north
            for (int n = row - 1; n >= 0; n--)
            {
                dist[2]++;
                if (forest[row, col] <= forest[n, col])
                {
                    break;
                }
            }


            // Check distance south
            for (int s = row + 1; s <= forest.GetLength(0) - 1; s++)
            {
                dist[3]++;
                if (forest[row, col] <= forest[s, col])
                {
                    break;
                }
            }

            return dist.Aggregate(1, (a, b) => a * b);
        }

        private long CheckIsVisibleFromEdge(int row, int col)
        {
            long result = 4;
            bool blocked = false;

            // Check visible from west
            for (int w = col - 1; w >= 0; w--)
            {
                if (forest[row, col] <= forest[row, w])
                {
                    result--;
                    blocked = true;
                    break;
                }
            }

            if (!blocked)
                return 1;
            else
                blocked = false;

            // Check visible from east
            for (int e = col + 1; e <= forest.GetLength(1) - 1; e++)
            {
                if (forest[row, col] <= forest[row, e])
                {
                    result--;
                    blocked = true;
                    break;
                }
            }

            if (!blocked)
                return 1;
            else
                blocked = false;

            // Check visible from north
            for (int n = row - 1; n >= 0; n--)
            {
                if (forest[row, col] <= forest[n, col])
                {
                    result--;
                    blocked = true;
                    break;
                }
            }

            if (!blocked)
                return 1;
            else
                blocked = false;

            // Check visible from south
            for (int s = row + 1; s <= forest.GetLength(0) - 1; s++)
            {
                if (forest[row, col] <= forest[s, col])
                {
                    result--;
                    blocked = true;
                    break;
                }
            }

            return !blocked ? 1 : 0;
            //return result > 0 ? 1 : 0;
        }

        #endregion

    }
}
