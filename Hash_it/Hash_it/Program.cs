using System;
using System.Collections.Generic;

namespace Hash_it
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> res = new LinkedList<string>();
            int t = int.Parse( Console.ReadLine());
            MyHashTable myHashTable = new MyHashTable();

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                for (int j = 0; j < n; j++)
                {
                    string[] input = Console.ReadLine().Split(':');
                    char op = input[0][0];
                    string s = input[1];

                    if (op == 'A')
                        myHashTable.Add(s);
                    else
                        myHashTable.Lazy_Delete(s);
                }

                myHashTable.Print(res);
                myHashTable.Clear();
            }

            foreach(string s in res)
                Console.WriteLine(s);

            Console.ReadKey();

        }


        public class MyHashTable
        {

            public Key[] Table = new Key[101];
            public int Count;
            public MyHashTable()
            {
                for(int i = 0; i < 101; i++)
                    Table[i] = new MyHashTable.Key("0");
            }

            public class Key
            {
                public Key(string k)
                {
                    this.key = k;
                }

                public string key;
                public bool TombStone = false;
            }

            public int Hash(string s)
            {
                int res = 0, i = 1;
                foreach (char c in s)
                    res += (i++ * (int)c);

                res = (19*res)%101;
                return res;
            }

            //(Hash(key)+j2+23*j) mod 101
            public int ReHash(int h, int j)
            {
                return (h + Convert.ToInt32(Math.Pow(j,2)) + (23 * j))%101;
            }

            public void Lazy_Delete(string s)
            {
                int h = Hash(s);
                for (int j = 0; j < 20; j++)
                {
                    int n = ReHash(h, j);
                    if(string.Equals(Table[n].key, s))
                    {
                        Table[n].TombStone = true;
                        Count--;
                        return;
                    }
                }
            }

            public void Add(string s)
            {
                int h = Hash(s);
                for (int j = 0; j < 20; j++)
                {
                    int n = ReHash(h, j);
                    if(string.Equals(Table[n].key,s) && Table[n].TombStone == false)
                        return;

                    if(string.Equals(Table[n].key, "0"))
                    {
                        Table[n] = new MyHashTable.Key(s);
                        Table[n].TombStone = false;
                        Count++;
                        break;
                    }
                }

            }

            public void Clear()
            {
                for (int i = 0; i < Table.Length; i++)
                {
                    Table[i].key = "0";
                    Table[i].TombStone = false;
                }
                Count = 0;
            }

            public void Print(LinkedList<string> list)
            {
                list.AddLast(new LinkedListNode<string>(Convert.ToString(Count)));
                for (int i = 0; i < 101; i++)
                    if(Table[i].TombStone == false && !string.Equals(Table[i].key,"0"))
                        list.AddLast(new LinkedListNode<string>(Convert.ToString(i) + ":" + Table[i].key));        
            }


        }

    }

}


