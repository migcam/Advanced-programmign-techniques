using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SBANK
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var res = new List<string>();

            for (int i = 0; i < n; i++)
            {
                int j = int.Parse(Console.ReadLine());
                
                Dictionary<string, int> frec = new Dictionary<string, int>();
                Dictionary<string, bool> constain = new Dictionary<string, bool>();

                string[] arr = new string[j];
                for (int u = 0; u < j; u++)
                {
                    arr[u] = Console.ReadLine();
                    try
                    {
                        frec.Add(arr[u], 1);
                        constain.Add(arr[u], false);
                    }
                    catch
                    {
                        frec[arr[u]]++;
                        constain[arr[u]] = false;
                    }
                }

                Array.Sort(arr);

                for(int u =0; u<j; u++)
                {
                    if(!constain[arr[u]])
                    {
                        res.Add(arr[u] + " " + frec[arr[u]]);
                        constain[arr[u]] = true;
                    }
                }


                //int count = 1;
                //for (int u = 0; u < j; u++)
                //{
                //    if (u == j - 2)
                //    {
                //        if (arr[u].Equals(arr[u + 1]))
                //        {
                //            res.Add(arr[u] + " " + ++count);
                //        }
                //        else
                //        {
                //            res.Add(arr[u] + " " + count);
                //            res.Add(arr[u + 1] + " " + "1");
                //        }

                //        break;
                //    }

                //    if (arr[u].Equals(arr[u + 1]))
                //    {
                //        count++;
                //    }
                //    else
                //    {
                //        res.Add(arr[u] + " " + count);
                //        count = 1;
                //    }
                //}



                //



                //SortedDictionary<string, int> y = new SortedDictionary<string, int>();
                //for (int u = 0; u < j; u++)
                //{
                //    string line = Console.ReadLine();
                //    try
                //    {
                //        y.Add(line, 1);
                //    }
                //    catch (ArgumentException)
                //    {
                //        y[line]++;
                //    }
                //}

                //foreach (var item in y)
                //{
                //    res.AddLast(item.Key + " " + item.Value);
                //}

                ////y.Clear();

                res.Add("");

                Console.ReadLine();
            }

            foreach(var item in res)
            {
                if (item.Equals(""))
                    Console.WriteLine();
                else
                    Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}
