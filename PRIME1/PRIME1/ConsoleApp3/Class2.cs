using System;
using System.Numerics;
class PRIME1
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        
        long[] M = new long[t], N = new long[t];
        //Sqrt(3200)
        long[] primes = Mark2(3200);
        for (int i = 0; i < t; i++)
        {
            string[] Case = Console.ReadLine().Split(' ');
            M[i] = int.Parse(Case[0]);
            N[i] = int.Parse(Case[1]);
        }

        Console.WriteLine();
        for (int i = 0; i < t; i++)
        {
            SegmentedMark2(M[i], N[i], primes);
            Console.WriteLine();
        }

        Console.ReadLine();
    }

    private static void SegmentedMark2(long M, long N, long[] primes)
    {
        if (M < 2)
            M = 2;

        bool[] range = new bool[N - M + 1];

        for (int i = 0; i < primes.Length; i++)
            for (long u = M; u <= N; u++)
                if (range[u - M] == false)
                    if (u % primes[i] == 0 && u != primes[i])
                        range[u - M] = true;

        for (int i = 0; i < range.Length; i++)
            if (range[i] == false)
                Console.WriteLine(i + M);
    }

    public static long[] Mark2(int b)
    {
        bool[] arr = new bool[b];
        int[] res = new int[(b / 2) + 1];

        for (long i = 2; i <= Math.Sqrt(b) + 1; i++)
            if (arr[i] == false)
                for (long j = i; j < b / i; j++)
                    arr[i * j] = true;

        res[0] = 2;
        int cont = 1;
        for (int u = 3; u < b; u += 2)
            if (arr[u] == false)
                res[cont++] = u;            

        long[] primes = new long[cont];
        cont = 0;
        while (res[cont] != 0)
            primes[cont] = res[cont++];

        return primes;
    }
}