using System;
using Algorithms.Lib.Sorting;
using Algorithms.Lib.Utils;


public class HeapSort : ISort
{
    public void Sort<T>(T[] collection, Func<T, T, int> c)
    {
        BuildHeap(collection, c);
        for (int i = collection.Length - 1; i > 0; i--)
        {
            collection.Swap(0, i);
            ShiftDown(collection, 0, i - 1, c);
        }
    }

    private void ShiftDown<T>(T[] heap, int start, int end, Func<T, T, int> c)
    {
        int root = start;
        while (((2 * root) + 1) <= end)
        {
            int child = (2 * root) + 1;
            int swap = root;

            if (c(heap[swap], heap[child]) < 0)
            {
                swap = child;
            }
            if (child + 1 <= end && c(heap[swap], heap[child + 1]) < 0)
            {
                swap = child + 1;
            }
            if (swap == root)
            {
                return;
            }
            else
            {
                heap.Swap(root, swap);
                root = swap;
            }
        }
    }

    private void BuildHeap<T>(T[] collection, Func<T, T, int> c)
    {
        for (int i = ParentI(collection.Length - 1); i >= 0; i--)
        {
            ShiftDown(collection, i, collection.Length - 1, c);
        }
    }

    private static int ParentI(int i)
    {
        return (int)Math.Floor((i - 1) / 2.0);
    }


}