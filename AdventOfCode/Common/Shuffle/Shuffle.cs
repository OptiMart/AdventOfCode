using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Shuffle
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
            catch (Exception ex)
            {
                throw ex;
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
    }
}
