using AoC.Puzzles.Puzzle.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Puzzle.Year2022
{
    /// <summary>
    /// Rope Bridge
    /// </summary>
    public class Puzzle2022Day09 : PuzzleBase
    {
        #region Data
        Dictionary<int, List<Tuple<int, int>>> Positions = new Dictionary<int, List<Tuple<int, int>>>();
        //Tuple<int, int> HeadPosition = new Tuple<int, int>(0, 0);
        //Tuple<int, int> TailPosition = new Tuple<int, int>(0, 0);
        int HeadPosX = 0;
        int HeadPosY = 0;

        #endregion

        #region Methods
        protected override void DoPreparations()
        {
            base.DoPreparations();

            // Add Head
            List<Tuple<int, int>> head = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0) };
            Positions.Add(0, head);

            // Add Tail - Part 1

            foreach (var dir in PuzzleItems)
            {
                int count = int.Parse(dir.Split(' ')[1]);
                switch (dir.Substring(0, 1))
                {
                    case "R":
                        MoveHead(head, count, 0);
                        break;

                    case "L":
                        MoveHead(head, -count, 0);
                        break;

                    case "U":
                        MoveHead(head, 0, count);
                        break;

                    case "D":
                        MoveHead(head, 0, -count);
                        break;

                    default:
                        break;
                }
            }
        }

        protected override string SolvePuzzlePartOne()
        {
            long result = 0;

            // Add Tail - Part 1
            List<Tuple<int, int>> tail = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0) };
            Positions.Add(1, tail);

            foreach (var move in Positions.First(x => x.Key == 0).Value)
            {
                MoveTail(tail, move);
            }

            result = tail.Distinct().Count();

            Console.WriteLine($"{result}");
            return result.ToString();
        }

        protected override string SolvePuzzlePartTwo()
        {
            long result = 0;

            for (int i = 2; i < 10; i++)
            {
                // Add Tail - Part i
                List<Tuple<int, int>> tail = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0) };
                Positions.Add(i, tail);

                foreach (var move in Positions.First(x => x.Key == i - 1).Value)
                {
                    MoveTail(tail, move);
                }
            }

            result = Positions.First(x => x.Key == 9).Value.Distinct().Count();
            Console.WriteLine($"{result}");
            return result.ToString();
        }

        private void MoveHead(List<Tuple<int, int>> list, int x, int y)
        {
            for (int i = 0; i < Math.Abs(x) + Math.Abs(y); i++)
            {
                list.Add(new Tuple<int, int>(list.Last().Item1 + Math.Sign(x), list.Last().Item2 + Math.Sign(y)));
                //HeadPosX += Math.Sign(x);
                //HeadPosY += Math.Sign(y);

                //CheckTail();
            }
        }

        private void MoveTail(List<Tuple<int, int>> tail, Tuple<int, int> move)
        {
            int tailx = tail.Last().Item1;
            int taily = tail.Last().Item2;

            if (Math.Abs(move.Item1 - tailx) > 1 || Math.Abs(move.Item2 - taily) > 1)
            {
                // not same row and col
                tailx += Math.Sign(move.Item1 - tailx);
                taily += Math.Sign(move.Item2 - taily);

                tail.Add(new Tuple<int, int>(tailx, taily));

            }
            //else if (Math.Abs(HeadPosX - tailx) > 1 || Math.Abs(HeadPosY - taily) > 1)
            //{
            //    // same row || col - 2 fields away
            //}
        }

        #endregion

    }
}
