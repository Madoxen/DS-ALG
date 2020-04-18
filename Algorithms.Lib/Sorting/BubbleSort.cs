using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Algorithms.Lib.Sorting
{
    public class BubbleSort : ISort
    {
        public void Sort<T>(T[] collection, Func<T, T, int> c)
        {
            for (int i = 1; i < collection.Length; i++)
            {
                for (int j = collection.Length - 1; j >= i; j--)
                {
                    if (c(collection[j - 1], collection[j]) > 0)
                    {
                        T buff = collection[j - 1];
                        collection[j - 1] = collection[j];
                        collection[j] = collection[j - 1];
                    }
                }
            }
        }
    }


}