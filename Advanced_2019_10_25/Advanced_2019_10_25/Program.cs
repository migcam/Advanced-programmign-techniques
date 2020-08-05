using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_2019_10_25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a number:");
            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(n);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.WriteLine(Console.ReadLine());

            //string Message = Console.ReadLine();
            //char last = (char)65; // Message[Message.Length - 1];
            //int answer = 0;

            //for (int i = 0; i < Message.Length; i++)
            //{
            //    if (last == Message[i])
            //        answer++;
            //}

            //Console.WriteLine(answer);

            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}
