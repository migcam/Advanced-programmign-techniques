using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt16(Console.ReadLine());

            long[] a = new long[n], b = new long[n];
            long max = 0;

            for (int i = 0; i < n; i++)
            {
                string[] Case = Console.ReadLine().Split(' ');
                a[i] = Convert.ToInt64(Case[0]);
                b[i] = Convert.ToInt64(Case[1]);
                if (b[i] > max)
                    max = b[i];
            }

            bool[] arr = new bool[max + 1];
            Mark(2, max, arr);

            for (int i = 0; i < n; i++)
                Print(a[i], b[i], arr);

            Console.ReadLine();
        }

        public static void Mark(long a, long b, bool[] arr)
        {
            for(long i = 2; i< Math.Sqrt(b);i++)
                if(arr[i] == false)
                    for(long j = i; j<=b/i; j++)
                        arr[i*j] = true;
        }


        public static void Print(long a, long b, bool[] arr)
        {
            for (long y = a; y <= b; y++)
                if (!arr[y] && y >= a)
                    Console.WriteLine(y);

            Console.WriteLine();
        }
    }
}
