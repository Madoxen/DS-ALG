using System;
using System.Collections.Generic;
using System.Collections;

namespace Algorithms.Lib.Sorting
{
    public class QuickSort : ISort
    {

        public void Sort<T>(T[] collection, Func<T, T, int> c)
        {
            Stack<int> indexes = new Stack<int>();
            indexes.Push(0);
            indexes.Push(collection.Length - 1);

            while (indexes.Count > 0)
            {
                int head = indexes.Pop();
                int lead = indexes.Pop();

                int pivot = Partition(collection, lead, head, c);

                if (pivot - 1 > lead) //if there are elements on the left of the pivot
                {
                    //push left side
                    indexes.Push(lead);
                    indexes.Push(pivot - 1);
                }

                if (pivot + 1 < head) //if there are elements on the right of a pivot
                {
                    //push right side
                    indexes.Push(pivot + 1);
                    indexes.Push(head);
                }
            }
        }


        private static int Partition<T>(T[] arr, int l, int h, Func<T, T, int> c)
        {
            T val = arr[h];
            int i = l - 1;

            for (int j = l; j <= h - 1; j++)
            {
                if (c(arr[j], val) <= 0)
                {
                    i++;
                    T buffr = arr[i];
                    arr[i] = arr[j];
                    arr[j] = buffr;
                }
            }
            T buff = arr[i + 1];
            arr[i + 1] = arr[h];
            arr[h] = buff;
            return i + 1;
        }
    }
}