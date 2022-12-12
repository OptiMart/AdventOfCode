using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.Extensions
{
    internal static class ListExtensions
    {
        public static string PrintList<T>(this IEnumerable<T> list)
        {
            return list.PrintList(string.Empty);
        }

        public static string PrintList<T>(this IEnumerable<T>list, string separator)
        {
            StringBuilder stringBuilder= new StringBuilder();
            foreach (T item in list)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(separator);
            }
            stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
            return stringBuilder.ToString();
        }

        public static bool ListContainsAllItems<T>(this IEnumerable<T> list, IEnumerable<T> compare)
        {
            return list.Intersect(compare).Count() == compare.Count();
        }

        public static bool IsSubsetOfList<T>(this IEnumerable<T> list, IEnumerable<T> compare)
        {
            return compare.ListContainsAllItems(list);
        }

        public static bool ListContainsAnyItem<T>(this IEnumerable<T> list, IEnumerable<T> compare)
        {
            return list.Intersect(compare).Any();
        }
    }
}
