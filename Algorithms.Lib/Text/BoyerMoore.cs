using System;


namespace Algorithms.Lib.Text
{

    public class BoyerMoore
    {
        const int tablesLength = char.MaxValue + 1; //controls length of bad char table
        int[] badTable; //Bad char tables
        int[] goodTable; //good suffix table
        string pattern;

        public BoyerMoore(string pattern)
        {
            this.pattern = pattern;
            CreateBadTable(pattern);
            CreateGoodSuffixTable(pattern);
        }
        public int Find(string input)
        {
            if(pattern.Length > input.Length)
                throw new ArgumentException("Pattern length cannot be bigger then input length.");

            if (pattern.Length == 0)
            {
                return 0;
            }

            int j = 0;
            int i = 0;

            for (i = pattern.Length - 1; i < input.Length;)
            {
                for (j = pattern.Length - 1; pattern[j] == input[i]; j--)
                {
                    if (j == 0)
                    {
                        return i;
                    }
                    i--;
                }
                i += Math.Max(goodTable[pattern.Length - 1 - j], badTable[input[i]]);
            }
            return -1;
        }


        private void CreateBadTable(string pattern)
        {
            badTable = new int[tablesLength]; //create table for every ASCII character
            for (int i = 0; i < badTable.Length; i++)
            {
                badTable[i] = pattern.Length; //if character does not exist in the pattern, move by whole pattern length
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                badTable[pattern[i]] = pattern.Length - i;
            }
        }


        private void CreateGoodSuffixTable(string pattern)
        {
            goodTable = new int[pattern.Length];
            int lastPrefixPosition = pattern.Length;
            for (int i = pattern.Length; i > 0; --i)
            {
                if (isPrefix(pattern, i))
                {
                    lastPrefixPosition = i;
                }
                goodTable[pattern.Length - i] = lastPrefixPosition - i + pattern.Length;
            }
            for (int i = 0; i < pattern.Length - 1; ++i)
            {
                int slen = suffixLength(pattern, i);
                goodTable[slen] = pattern.Length - 1 - i + slen;
            }
        }

        /**
         * Is needle[p:end] a prefix of needle?
         */
        private static bool isPrefix(string pattern, int p)
        {
            for (int i = p, j = 0; i < pattern.Length; ++i, ++j)
            {
                if (pattern[i] != pattern[j])
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Returns the maximum length of the substring ends at p and is a suffix.
         * (good suffix rule)
         */
        private static int suffixLength(string pattern, int p)
        {
            int len = 0;
            for (int i = p, j = pattern.Length - 1;
                     i >= 0 && pattern[i] == pattern[j]; --i, --j)
            {
                len += 1;
            }
            return len;
        }



    }

}