using AoC.Puzzles.Common.Extensions;
using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Pyroclastic Flow
    /// </summary>
    public class Puzzle2022Day17 : PuzzleBase
    {
        #region Data
        Chamber Chamber;
        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();
            //Chamber = new Chamber(PuzzleInput) { MaxWidth = 7 };
            Chamber = new Chamber(">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>") { MaxWidth = 7 };
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;

            Chamber.Droprocks(2022);

            result = Chamber.MaxHeight;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        #endregion

    }

    internal class Chamber
    {
        #region Constructor
        public Chamber(string jetPattern)
        {
            InitRocks();
            JetPattern = jetPattern;
        }

        #endregion

        #region Properties
        public int MaxWidth { get; init; } = 0;
        public int MaxHeight { get; set; } = 0;
        public int WallHeight => Wall.Max(w => w.y);
        public List<Rock> NewRocks { get; private set; }
        public List<Rock> Rocks { get; init; } = new List<Rock>();
        public List<(int x, int y)> Blocked { get; private set; } = new List<(int x, int y)>();
        public List<(int x, int y)> Wall { get; private set; } = new List<(int x, int y)>();
        public int CountRocks => Rocks.Count;
        public Rock FallingRock { get; private set; }
        public string JetPattern { get; set; }
        public int JetCount { get; private set; } = 0;
        public int Movements { get; private set; } = 0;

        #endregion

        #region Methods
        public void InitRocks()
        {
            NewRocks = new List<Rock>()
            {
                new Rock(new List<(int x, int y)>() { (0, 0), (1, 0), (2, 0), (3, 0) }),
                new Rock(new List<(int x, int y)>() { (1, 0), (0, 1), (1, 1), (2, 1), (1, 2) }),
                new Rock(new List<(int x, int y)>() { (0, 0), (1, 0), (2, 0), (2, 1), (2, 2) }),
                new Rock(new List<(int x, int y)>() { (0, 0), (0, 1), (0, 2), (0, 3) }),
                new Rock(new List<(int x, int y)>() { (0, 0), (1, 0), (0, 1), (1, 1) })
            };
        }

        public void BuildWalls(int height)
        {
            if (!Wall.Any())
            {
                for (int i = 0; i <= MaxWidth + 1; i++)
                {
                    Wall.Add((i, 0));
                    Blocked.Add((i, 0));
                }
            }

            for (int y = WallHeight; y <= height; y++)
            {
                Wall.Add((0, y));
                Wall.Add((MaxWidth + 1, y));
            }

            //WallHeight = height;
        }

        public void Droprocks(int count)
        {
            DropNextRock();
            do
            {
                if (!TryMoveFallingRock(GetNextJetDirection()))
                {
                    FallingRock.StopFalling();
                    Rocks.Add(FallingRock);
                    Blocked.AddRange(FallingRock.Blocked);

                    if (FallingRock.Blocked.Max(r => r.y) > MaxHeight)
                    {
                        MaxHeight = FallingRock.Blocked.Max(r => r.y);
                    }
                    else
                    {
                        int dif = FallingRock.Blocked.Max(r => r.y) - MaxHeight;
                    }

                    DropNextRock();
                }

            } while (CountRocks < count);
        }

        public void DropNextRock()
        {
            FallingRock = (Rock)NewRocks[CountRocks % NewRocks.Count].Clone();
            FallingRock.Position = (3, MaxHeight + 4);
            FallingRock.IsMoving = true;

            BuildWalls(MaxHeight + 4 + FallingRock.Height);
        }

        public int GetNextJetDirection()
        {
            int dir = 0;
            switch (JetPattern[JetCount++ % JetPattern.Length])
            {
                case '<':
                    dir = -1;
                    break;
                case '>':
                    dir = 1;
                    break;
            }
            //JetCount %= JetPattern.Length;
            
            return dir;
        }

        public bool TryMoveFallingRock(int horizontal)
        {
            // First move horizontaly
            //var test = FallingRock.TryMoveRelative(0, horizontal);

            if (!Blocked.Union(Wall).ListContainsAnyItem(FallingRock.TryMoveRelative(horizontal, 0)))
                FallingRock.MoveRelative(horizontal, 0);

            Movements += 2;

            // Check downward movement
            if (Blocked.ListContainsAnyItem(FallingRock.TryMoveRelative(0, -1)))
            {
                return false;
            }
            else
            {
                FallingRock.MoveRelative(0, -1);
                return true;
            }
        }

        #endregion
    }

    internal class Rock : ICloneable
    {
        #region Constructor
        public Rock(List<(int, int)> shape)
        {
            Shape = shape;
            Height = Shape.Max(r => r.y + 1);
            Width = Shape.Max(r => r.x + 1);
        }

        #endregion

        #region Properties
        public List<(int x, int y)> Shape { get; private set; }
        public (int x, int y) Position { get; set; } = (0, 0);
        public List<(int x, int y)> Blocked { get; set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public bool IsMoving { get; set; }
        public bool IsStopped => !IsMoving;

        #endregion

        #region Methods
        public List<(int x, int y)> TryMoveRelative(int x, int y)
        {
            return TryMoveAbsolute(Position.x + x, Position.y + y);
        }

        public List<(int x, int y)> TryMoveAbsolute(int x, int y)
        {
            List<(int x, int y)> result = new();

            foreach (var item in Shape)
            {
                result.Add((item.x + x, item.y + y));
            }

            return result;
        }

        public void MoveRelative(int x, int y)
        {
            MoveAbsolute(Position.x + x, Position.y + y);
        }

        public void MoveAbsolute(int x, int y)
        {
            Position = (x, y);
        }

        public void StopFalling()
        {
            IsMoving = false;
            Blocked = TryMoveRelative(0, 0);
        }

        public object Clone()
        {
            return new Rock(Shape);
        }

        #endregion
    }
}
