using System;

namespace Algorithms.Lib.Text
{
    public static class KarpRabin
    {
        const uint PRIME_BASE = 256;
        const uint PRIME_MOD = 101;

        //Returns index of first occurence or -1 if pattern was not found in the input string
        public static int Find(string input, string pattern)
        {
            uint hashInput = 0;
            uint hashPattern = Hash(pattern);
            for (int i = 0; i < input.Length - pattern.Length + 1; i++)
            {
                hashInput = Hash(input.Substring(i, pattern.Length));
                if (hashInput == hashPattern)
                {
                    if (input.Substring(i, pattern.Length).CompareTo(pattern) == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private static uint Hash(string str)
        {

            uint val = 0;
            foreach (char c in str)
            {
                val *= PRIME_BASE;
                val += c;
                val %= PRIME_MOD;
            }
            return val;
        }
    }
}