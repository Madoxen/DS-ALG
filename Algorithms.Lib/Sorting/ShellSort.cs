using System;

namespace Algorithms.Lib.Sorting
{
    public class ShellSort : ISort
    {
        //Use Marcin Ciura's gap sequence
        static int[] gaps = new int[] { 701, 301, 132, 57, 23, 10, 4, 1 };

        public void Sort<T>(T[] collection, Func<T, T, int> c)
        {
            // Start with the largest gap and work down to a gap of 1
            foreach (int gap in gaps)
            {
                // Do a gapped insertion sort for this gap size.
                // The first gap elements a[0..gap-1] are already in gapped order
                // keep adding one more element until the entire array is gap sorted

                for (int i = gap; i < collection.Length; i += 1)
                {
                    // add a[i] to the elements that have been gap sorted
                    // save a[i] in temp and make a hole at position i
                    T temp = collection[i];
                    int j = 0;
                    // shift earlier gap-sorted elements up until the correct location for collection[i] is found
                    for (j = i; j >= gap && c(collection[j - gap], temp) > 0; j -= gap)
                    {
                        collection[j] = collection[j - gap];
                    }
                    // put temp (the original collection[i]) in its correct location
                    collection[j] = temp;
                }
            }

        }

    }
}