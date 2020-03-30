using System;

namespace Algorithms.Lib
{
    class intUtils
    {

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
