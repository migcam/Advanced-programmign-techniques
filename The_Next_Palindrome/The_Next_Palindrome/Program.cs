using System;
using System.Text;

namespace The_Next_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            StringBuilder[] cases = new StringBuilder[t];
            int initial = 0;
            for (int i = initial; i < t; i++)
                cases[i] = new StringBuilder(Convert.ToString(i));

            StringBuilder[] result = new StringBuilder[t];
            StringBuilder j = new StringBuilder();
            for (int i = 0; i < t; i++)
            {
                //j = new StringBuilder(Console.ReadLine());
                j = cases[i];
                result[i] = Looking(j);
            }

            for (int i = 0; i < result.Length; i++)
            {
                if(result[i].ToString().Contains(':'))
                    Console.WriteLine(result[i] + " "+ i);
            }
        }

        public static StringBuilder Looking(StringBuilder s)
        {
            if (s[0] == s[s.Length - 1])
            {
                if (s.Length == 1)
                {
                    if (s[0] == '9')
                        return new StringBuilder("11");

                    int u = (int)Convert.ToChar(s[0] + 1);
                    return new StringBuilder(Convert.ToString((char)u));
                    
                }

                bool nine = true;
                for (int a = 0; a < s.Length - 1; a++)
                {
                    if (s[a] != '9')
                        nine = false;
                }

                if (nine)
                {
                    s[0] = '1';
                    for (int t = 1; t < s.Length; t++)
                        s[t] = '0';

                    s.Append('1');

                    return s;
                }
                else
                {
                    bool poli = true;
                    for(int i = 0, j = s.Length-1; i<j; i++, j--)
                    {
                        if(s[i] != s[j])
                        {
                            poli = false;
                            break;
                        }
                    }

                    if (poli)
                    {
                        int u = (int)Convert.ToChar(s[s.Length-1]) + 1;
                        s[s.Length-1] = (char)u;                                           
                    }
                }
            }

            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                if(s[i] == s[j] && j-i <4)
                {
                    if (j - i == 1  && s[i+1] == '9')
                    {
                        int u = (int)Convert.ToChar(s[i]) + 1;
                        s[i] = (char)u;
                        s[i+1] = '0';
                        s[j] = s[i];
                    }
                }
                else if (j == i + 1)
                {
                    if (s[j] > s[i])
                    {
                        int u = (int)Convert.ToChar(s[i]) + 1;
                        s[i] = (char)u;
                        s[i + 1] = '0';
                        s[j] = s[i];
                    }
                    else
                    {
                        s[j] = s[i];
                    }
                }
                else if (s[i] > s[j])
                {
                    s[j] = s[i];
                }
                else
                {
                    s[j] = s[i];
                    int u = (int)Convert.ToChar(s[j - 1]) + 1;
                    s[j - 1] = (char)u;
                }
            }

            return s;
        }
    }
}
