using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            
            if(s.Length % 2 != 0)
                Console.WriteLine("NO");
            else
            {
                int i = 0, j = s.Length - 1;
                bool check = true;
                while(i < j)
                {
                    if (s[i] != s[j])
                    {
                        check = false;
                        break;
                    }
                    ++i;
                    --j;
                }
                if (check)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }

            Console.ReadKey();
        }
    }
}
