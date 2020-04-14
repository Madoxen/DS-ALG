using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Lib.Graphs;
using System.Linq;
using System.Text;

namespace Algorithms.Lib.Compression
{
    public class Huffman
    {

        HuffmanNode root;
        List<Word> words = new List<Word>();
        public string Encode(byte[] data)
        {

            //1. Calculate word probabilities
            words = new List<Word>();
            foreach (byte b in data)
            {
                Word currWord = words.Find(x => x.value == b);
                if (currWord != null)
                {
                    currWord.probability++;
                }
                else
                {
                    words.Add(new Word() { value = b, probability = 1 });
                }
            }

            List<HuffmanNode> nodes = new List<HuffmanNode>();
            foreach (Word w in words)
                nodes.Add(new HuffmanNode() { w = w, prob = w.probability });
            //2. create dictionary tree
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes.Count <= 1)
                    break;

                HuffmanNode a = nodes.Aggregate((x, y) => x.prob < y.prob ? x : y);
                nodes.Remove(a);
                HuffmanNode b = nodes.Aggregate((x, y) => x.prob < y.prob ? x : y);
                nodes.Remove(b);

                HuffmanNode newNode = new HuffmanNode();
                newNode.child[0] = a;
                newNode.child[1] = b;
                newNode.prob = a.prob + b.prob;
                nodes.Add(newNode);
                i--;
            }

            root = nodes[0];
            setCodeToTheTree("", root);

            string code = "";
            for (int i = 0; i < data.Length; i++)
            {
                code += words.Find(x => x.value == data[i]).code;
            }
            return code;

        }

        //Using internal code decode data
        public string Decode(string encodedData)
        {
            int length = 1;
            string result = "";
            for (int i = 0; i < encodedData.Length;)
            {               
                while(true)
                {
                    Word w = words.Find(x=>x.code == new string(encodedData.Skip(i).Take(length).ToArray()));
                    if(w != null)
                    {
                        result += (char)w.value;
                        i += length;
                        length = 1;
                        break;
                    }
                    length++;
                }                
            }
            return result;
        }


        private class Word
        {
            public int probability;
            public byte value;
            public string code;

            public Word()
            {

            }
        }


        // Setting the codes of the nodes of tree. Recursive method.
        private static void setCodeToTheTree(string code, HuffmanNode root)
        {
            if (root == null)
                return;
            if (root.child[0] == null && root.child[1] == null)
            {
                root.currentCode = code;
                root.w.code = code;
                return;
            }
            setCodeToTheTree(code + "0", root.child[0]);
            setCodeToTheTree(code + "1", root.child[1]);
        }

        private class HuffmanNode
        {
            public HuffmanNode[] child = new HuffmanNode[2]; //0 is left 1 is right
            public string currentCode = "";
            public int prob = 0;
            public Word w = null;
        }


        private static bool[] stringToBool(string input)
        {
            bool[] result = new bool[input.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = input[i] == '1' ? true : false;
            }
            return result;
        }


    }

}