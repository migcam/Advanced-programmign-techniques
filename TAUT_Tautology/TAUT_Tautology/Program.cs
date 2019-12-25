using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TAUT_Tautology
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt16(Console.ReadLine());
            bool[] res = new bool[n];

            for (int i = 0; i < n; i++)
                res[i] = VerifyTautology(new StringBuilder(Console.ReadLine()));

            foreach (bool b in res)
            {
                if (b)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }

        }

        public static HashSet<char> Operators = new HashSet<char> { { 'E' }, { 'I' }, { 'D' }, { 'C' }, { 'N' } };

        public static bool VerifyTautology(StringBuilder input)
        {
            OriginalExpresion = new StringBuilder(input.ToString());

            //dic de indices y variables booleanas
            indexes = new Dictionary<int, char>();

            //dic de chars y sus valores de verdad
            CharValues = new Dictionary<char, int>();

            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!Operators.Contains(input[i]))
                {
                    if (!CharValues.ContainsKey(input[i]))
                    {
                        indexes.Add(count, input[i]);
                        count++;
                        CharValues.Add(input[i], 0);
                    }

                    input[i] = '0';
                }
            }

            int[] status = new int[CharValues.Count];
            memo = new bool[(int)Math.Pow(2, CharValues.Count)];

            answer = true;
            BF2(input, status, 0);

            return answer;
        }

        public static Dictionary<int, char> indexes;
        public static Dictionary<char, int> CharValues;
        public static StringBuilder OriginalExpresion;
        public static bool[] memo;

        public static bool VerifyBool(StringBuilder input)
        {
            StringBuilder tmp = new StringBuilder(input.ToString());
            Stack<char> MyStack = new Stack<char>();
            for (int i = tmp.Length - 1; i > -1; i--)
            {
                if (tmp[i] == 'C')
                {
                    UnitOperand(tmp, MyStack, i, (MyStack.Pop() == '0' || MyStack.Pop() == '0'));
                }
                else if (tmp[i] == 'D')
                {
                    UnitOperand(tmp, MyStack, i, (MyStack.Pop() == '0' && MyStack.Pop() == '0'));
                }
                else if (tmp[i] == 'N')
                {
                    char right = MyStack.Pop();
                    if (tmp[i + 1] == '1')
                        tmp[i] = '0';
                    else
                        tmp[i] = '1';

                    MyStack.Push(tmp[i]);
                    tmp.Remove(i + 1, 1);
                }
                else if (tmp[i] == 'I')
                {
                    var left = MyStack.Pop();
                    var right = MyStack.Pop();
                    UnitOperand(tmp, MyStack, i, (left == '1' && right == '0'));
                }
                else if (tmp[i] == 'E')
                {
                    UnitOperand(tmp, MyStack, i, (MyStack.Pop() != MyStack.Pop()));
                }
                else
                {
                    MyStack.Push(tmp[i]);
                }
            }

            if (tmp[0] == '1')
                return true;

            return false;
        }

        public static void UnitOperand(StringBuilder tmp, Stack<char> MyStack, int i, bool condition)
        {
            if (condition)
                tmp[i] = '0';
            else
                tmp[i] = '1';

            MyStack.Push(tmp[i]);
            tmp.Remove(i + 1, 2);
        }

        public static bool answer;

        public static void BF2(StringBuilder input, int[] status, int n)
        {
            int bin = BinToDec(status);
            if (memo[bin] == true)
                return;

            if (!VerifyBool(input))
                answer = false;

            if (n >= status.Length)
                return;

            //set it to 1
            int[] TmpStatus2 = new int[status.Length];
            status.CopyTo(TmpStatus2, 0);
            TmpStatus2[n] = 1;
            var tmp2 = new StringBuilder(OriginalExpresion.ToString());
            CharValues[indexes[n]] = 1;

            for (int i = 0; i < tmp2.Length; i++)
                if (CharValues.ContainsKey(tmp2[i]))
                    tmp2[i] = Convert.ToChar(CharValues[tmp2[i]] + 48);

            BF2(tmp2, TmpStatus2, n + 1);

            BF2(input, status, n + 1);


            memo[bin] = true;
        }

        public static int BinToDec(int[] status)
        {
            int res = 0;

            for (int i = 0, n = status.Length; i < status.Length; i++, n--)
            {
                res += status[i] * (int)Math.Pow(2, n - 1);
            }
            return res;
        }
    }
}


