//using System;
//class Program
//{
//    static void Main(string[] args)
//    {
//        int n = Convert.ToInt16(Console.ReadLine());
//        //string[] c = new string[n];
//        long[] a = new long[n], b = new long[n];
//        long maxA = 0;
//        long maxB = Convert.ToInt64(Math.Pow(10, 9));

//        for (int i = 0; i < n; i++)
//        {
//            string[] Case = Console.ReadLine().Split(' ');
//            a[i] = int.Parse(Case[0]);
//            b[i] = int.Parse(Case[1]);
//            if (a[i] > maxA)
//                maxA = a[i];

//            //if (b[i] > maxB)
//            //    maxB = b[i];
//        }

//        bool[] arr = new bool[maxB + 1];
//        //arr[11] = true;
//        arr[1] = true;

//        //sqrt(10^9)=32000
//        Mark(32000, arr);

//        for (int i = 0; i < n; i++)
//        {
//            SegmentedMark(a[i], b[i], arr);
//            Print(a[i], b[i], arr);
//            Console.WriteLine();
//        }

//        Console.ReadLine();
//    }

//    public static void SegmentedMark(long a, long b, bool[] arr)
//    {
//        for (long i = 2; i <= b; i++)
//        {
//            if (arr[i] == false)
//            {
//                for (long j = a; j <= b; j++)
//                {
//                    if (!(j % 1 == 0))
//                        Console.WriteLine(j);
//                }
//            }
//        }
//    }



//    public static void Mark(long b, bool[] arr)
//    {
//        for (long i = 2; i <= Convert.ToInt64(Math.Sqrt(b)); i++)
//            if (arr[i] == false)
//                for (long j = i; j <= b / i; j++)
//                    arr[i * j] = true;
//    }

//    public static void Print(long a, long b, bool[] arr)
//    {
//        for (long y = a; y <= b; y++)
//            if (!arr[y])
//                Console.WriteLine(y);

//        Console.WriteLine();
//    }
//}

