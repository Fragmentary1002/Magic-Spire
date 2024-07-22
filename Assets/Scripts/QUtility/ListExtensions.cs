using System;
using System.Collections.Generic;
using QFramework;

namespace QUtility
{ 
    public class ListExtensions : IUtility
    {

        public void Shuffle<T>(IList<T> list)
        {
            Random rnd = new Random();
            for (var i = 0; i < list.Count; i++)
               Swap(list,i, rnd.Next(i, list.Count));
        }

        public void Swap<T>(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}