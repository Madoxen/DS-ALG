using System;

namespace Algorithms.Lib.Sorting
{
    public class MergeSort : ISort
    {
        public void Sort<T>(T[] collection, Func<T, T, int> c)
        {
            T[] B = new T[collection.Length];
            collection.CopyTo(B, 0);
            SplitMerge(collection, B, 0, collection.Length, c);
            collection = B;
        }

        private void SplitMerge<T>(T[] A, T[] B, int start, int end, Func<T, T, int> c)
        {
            if (end - start < 2)
                return;

            int middle = (end + start) / 2;
            SplitMerge(B, A, start, middle, c);
            SplitMerge(B, A, middle, end, c);
            Merge(B, A, start, middle, end,c);
        }

        private void Merge<T>(T[] A, T[] B, int start, int middle, int end, Func<T, T, int> c)
        {
            int i = start;
            int j = middle;
            for (int k = start; k < end; k++)
            {
                if (i < middle && (j >= end || c(A[i], A[j]) <= 0))
                {
                    B[k] = A[i];
                    i = i + 1;
                }
                else
                {
                    B[k] = A[j];
                    j = j + 1;
                }
            }
        }



    }
}