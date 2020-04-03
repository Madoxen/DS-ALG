using System.Collections.Generic;

namespace Algorithms.Lib.Text
{
    public static class KMP
    {

        //Performs Knuth-Morris-Pratt algorithm
        //Returns index number on which pattern was found
        //Return -1 if pattern was not found in a provided string
        public static int Find(string pattern, string input)
        {
            int a = 0, b = 0;
            int[] last = createTable(pattern);
            while (a + b < input.Length)
            {
                if (pattern[b] == input[a + b])
                {
                    b++;
                    if (b == pattern.Length)
                        return a;
                }
                else
                {
                    a = a + b - last[b];
                    if (b > 0)
                        b = last[b];
                }
            }
            return -1;
        }

        private static int[] createTable(string pattern)
        {
            int i = 2;
            int j = 0;
            int[] lps = new int[pattern.Length];
            lps[0] = -1;
            lps[1] = 0;
            while (i < pattern.Length)
            {
                if (pattern[i - 1] == pattern[j])
                {
                    lps[i] = j + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                    {
                        j = lps[j];
                    }
                    else
                    {
                        lps[i] = 0; i++;
                    }

                }
            }
            return lps;
        }

    }
}
