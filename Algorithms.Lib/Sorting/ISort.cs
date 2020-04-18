using System;

namespace Algorithms.Lib.Sorting
{
    public interface ISort
    {
        void Sort<T>(T[] collection, Func<T, T, int> c);
    }
}