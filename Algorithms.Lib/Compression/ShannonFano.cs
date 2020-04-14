using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.Compression
{
    public class ShannonFano
    {
        private Dictionary<string, char> wordDic = new Dictionary<string, char>();
        public Dictionary<string, char> WordDictionary
        {
            get { return wordDic; }
        }

        public string Encode(string input)
        {
            //Calculate probabilities of each word
            Dictionary<char, int> words = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (words.ContainsKey(c))
                {
                    words[c]++;
                }
                else
                {
                    words.Add(c, 1);
                }
            }
            //sort by probability
            var sortedWords = words.ToList();
            sortedWords.Sort((x, y) => -x.Value.CompareTo(y.Value));
            string lastCode = "0";
            for (int i = 0; i < sortedWords.Count - 1; i++)
            {
                WordDictionary.Add(lastCode, sortedWords[i].Key);
                lastCode = 1 + lastCode;
            }

            WordDictionary.Add(lastCode.Substring(0, lastCode.Length) + "1", sortedWords.Last().Key);


            string result = "";
            foreach (char c in input)
            {
                result += WordDictionary.First(x => x.Value == c).Key;
            }
            return result;
        }

        public string Decode(string encodedData)
        {
            int length = 1;
            string result = "";
            for (int i = 0; i < encodedData.Length;)
            {
                while (true)
                {
                    if (WordDictionary.TryGetValue(new string(encodedData.Skip(i).Take(length).ToArray()), out char w))
                    {
                        result += w;
                        i += length;
                        length = 1;
                        break;
                    }
                    length++;
                }
            }
            return result;
        }
    }

}