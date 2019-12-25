using System;
using System.Collections.Generic;

namespace Hash_it
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashTable myHashTable = new MyHashTable();
        }


        public class MyHashTable
        {
            
            public class Key
            {
                public Key(string k, bool t)
                {
                    this.key = k;
                    this.tombstone = t;
                }

                public string key;
                public bool tombstone;
            }

            public Key[] Table = new Key[101];

            public int Hash(string s)
            {
                int res = 0;
                for(int i =1; i<= s.Length; i++)
                    res += i * (int)s[i];

                res *= 19;
                res %= 101;

                return res;
            }

            public int Find(string s)
            {
                int n = Hash(s);
                while (Table[n].key != s)
                    n++;


            }
        }
    }
}
