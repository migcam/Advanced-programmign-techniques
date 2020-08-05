using System;
using System.Collections.Generic;

namespace ONP_Transform_to_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] myarray = new string[n];       

            for (int i = 0; i < n; i++)
                myarray[i] = ReverersedNotation(Console.ReadLine());

            for(int i=0; i < myarray.Length; i++)
                Console.WriteLine(myarray[i]);
        }

        public static Stack<char> MyStack = new Stack<char>();

        public static string ReverersedNotation(string input)
        {
            string res = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    MyStack.Push(input[i]);
                    continue;
                }

                if (input[i] == ')')
                {
                    res = res + MyStack.Pop();
                    continue;
                }

                if (input[i] == '+' || input[i] == '-' || input[i] == '*' ||
                    input[i] == '/' || input[i] == '^')
                {
                    MyStack.Pop();
                    MyStack.Push(input[i]);
                    continue;
                }

                res = res + input[i];
            }

            return res;
        }
    }
}
