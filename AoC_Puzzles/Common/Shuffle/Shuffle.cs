using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Shuffle
{
    public static class Shuffle
    {
        public static void DealIntoNew<T>(List<T> stack)
        {
            stack.Reverse();
        }

        public static void CutNElements<T>(List<T> stack, int elements)
        {
            int start = 0;
            int count = (stack.Count + elements) % stack.Count;

            try
            {
                var temp = stack.GetRange(start, count);
                stack.RemoveRange(start, count);
                stack.AddRange(temp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DealIncrement<T>(List<T> stack, int elements)
        {
            if (elements <= 0)
                return;

            SortedDictionary<int,T> test = new SortedDictionary<int, T>();

            int counter = 0;
            foreach (var item in stack)
            {
                test.Add(counter, item);
                counter = (counter + elements) % stack.Count;
            }

            stack.Clear();
            stack.AddRange(test.Values.ToList());
        }

        /// <summary>
        /// for a list of {1, 2, 3, 4} and a length of 2
        /// output: {1,1} {1,2} {1,3} {1,4} {2,1} {2,2} {2,3} {2,4} {3,1} {3,2} {3,3} {3,4} {4,1} {4,2} {4,3} {4,4}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetPermutationsWithRept<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutationsWithRept(list, length - 1)
                .SelectMany(t => list,
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary>
        /// for a list of {1, 2, 3, 4} and a length of 2
        /// output: {1,2} {1,3} {1,4} {2,1} {2,3} {2,4} {3,1} {3,2} {3,4} {4,1} {4,2} {4,3}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary>
        /// for a list of {1, 2, 3, 4} and a length of 2
        /// output: {1,1} {1,2} {1,3} {1,4} {2,2} {2,3} {2,4} {3,3} {3,4} {4,4}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetKCombsWithRept<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombsWithRept(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) >= 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary>
        /// for a list of {1, 2, 3, 4} and a length of 2
        /// output: {1,2} {1,3} {1,4} {2,3} {2,4} {3,4}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
