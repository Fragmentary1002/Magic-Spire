using System;
using System.Collections.Generic;
using QFramework;

namespace QUtility
{ 
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rnd = new Random();
            for (var i = 0; i < list.Count; i++)
                list.Swap(i, rnd.Next(i, list.Count));
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}