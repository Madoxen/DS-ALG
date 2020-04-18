namespace Algorithms.Lib.Utils
{
    public static class ArraySwapUtil
    {
        public static void Swap<T>(this T[] arr, int a, int b)
        {
            T buff = arr[a];
            arr[a] = arr[b];
            arr[b] = buff;
        }
    }
    
}