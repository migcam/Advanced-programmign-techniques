using System;
using System.Text;


namespace The_Next_Palindrome_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            StringBuilder[] res = new StringBuilder[t];

            StringBuilder input = new StringBuilder();
            for (int i = 0; i < t; i++)
            {
                string StrInput = Convert.ToString(Convert.ToInt32(Console.ReadLine()) + 1);
                input = new StringBuilder(StrInput);

                //input = new StringBuilder(Convert.ToString(i+1));

                res[i] = Create_Palin(input);

            }

            for (int i = 0; i < t; i++)
            {
                //if(res[i].ToString().Contains(':'))
                    Console.WriteLine(res[i] + " " + i);
            }

            Console.ReadKey();
        }

        private static StringBuilder Create_Palin(StringBuilder input)
        {
            
            for (int i = 0, j=input.Length-1; i < j; i++,j--)
            {
                if(input[i] == input[j])
                {
                    continue;
                }
                else if(input[i] > input[j])
                {
                    input[j] = input[i];
                }
                else if (input[j] > input[i])
                {
                    input = Sum(input, input[i], j);
                    i--;
                    j++;
                }

            }

            return input;
        }


        public static StringBuilder Sum(StringBuilder s, char StartValue ,int StartIndex)
        {
            s[StartIndex] = StartValue;
            StartIndex--;

            while (s[StartIndex] == '9')
            { 
                s[StartIndex] = '0';
                StartIndex--;
            }

            int u = (int)s[StartIndex] + 1;
            s[StartIndex] = (char)u;

            return s;
        }
    }
}
