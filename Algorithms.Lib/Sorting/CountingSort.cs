using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.Sorting
{
    public class CountingSort
    {
        public void Sort(int[] array)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();

            //Create value histogram
            for (int i = 0; i < array.Length; i++)
            {
                int value = array[i];
                if (count.ContainsKey(value))
                {
                    count[value]++;
                }
                else
                {
                    count.Add(value, 1);
                }
            }

            count = count.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            int c = 0;
            foreach (KeyValuePair<int, int> pair in count)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    array[c] = pair.Key;
                    c++;
                }
            }
        }
    }
}
