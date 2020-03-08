using System;

namespace biggest_num
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(max(new int[] { -2, 1, 2, 3, 5 }));
        }

        static int max(int[] set)
        {
            int max = int.MinValue;
            foreach (int i in set)
            {
                if (max < i)
                    max = i;
            }
            return max;
        }
    }



}
