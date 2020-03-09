using System;
using System.Collections;
using System.Collections.Generic;


namespace postfixNotation
{
    class Program
    {
        static Dictionary<string, short> priorityMap = new Dictionary<string, short>();
        static void Main(string[] args)
        {
            //Initialize priority map
            priorityMap.Add("(", -1); //Using 
            priorityMap.Add(")", 0);
            priorityMap.Add("+", 0);
            priorityMap.Add("-", 0);
            priorityMap.Add("*", 1);
            priorityMap.Add("/", 1);
            priorityMap.Add("^", 2);


            string sentence = "62 * 2 + 1 * ( ( 2 - 2 ) * 3 )";
            Console.WriteLine(ConvertToReverseNotation(sentence));
            Console.WriteLine(ConvertToNormalNotation(ConvertToReverseNotation(sentence)));
        }

        static string ConvertToReverseNotation(string sentence)
        {
            string result = "";
            Stack<string> currentOperators = new Stack<string>();
            string[] tokens = sentence.Split(" ");
            foreach (string t in tokens)
            {

                //Check if current token is an operator
                if (!priorityMap.ContainsKey(t))
                {
                    //if not it's a number/letter
                    result += t + " ";
                    continue;
                }

                //if token is an operator...
                if (currentOperators.Count == 0 || t == "(")
                {
                    currentOperators.Push(t);
                    continue;
                }


                if (t == ")")
                {
                    while (currentOperators.Peek() != "(")
                    {
                        result += currentOperators.Pop() + " ";
                    }
                    //pop )
                    currentOperators.Pop();
                    continue;
                }


                while (currentOperators.Count != 0)
                {
                    if (priorityMap[currentOperators.Peek()] >= priorityMap[t])
                    {
                        result += currentOperators.Pop() + " ";
                    }
                    else { break; }
                }

                currentOperators.Push(t);
            }

            while (currentOperators.Count != 0)
            {
                result += currentOperators.Pop() + " ";
            }

            return result;
        }

        static string ConvertToNormalNotation(string sentence)
        {
            Stack<string> operands = new Stack<string>();
            string[] tokens = sentence.Split(" ");
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                string curr = tokens[i];
                if (!priorityMap.ContainsKey(curr))
                {
                    operands.Push(curr);
                    continue;
                }

                if (operands.Count < 2)
                    throw new ArgumentException("Not enough operands");


                string r = "(" + operands.Pop() + curr + operands.Pop() + ")";
                operands.Push(r);

            }

            return operands.Pop();
        }

    }
}
