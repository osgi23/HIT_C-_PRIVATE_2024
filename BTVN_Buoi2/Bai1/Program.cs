using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cd = int.Parse(Console.ReadLine());
            int cr = int.Parse(Console.ReadLine());

            for (int i = 0; i < cd; ++i)
            {
                Console.Write("*");
            }
            Console.WriteLine();


            for (int i = 1; i < cr - 1; ++i)
            {
                for (int j = 0; j < cd; ++j)
                {
                    if (j == 0 || j == cd - 1)
                        Console.Write("*");
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }

            for (int i = 0; i < cd; ++i)
            {
                Console.Write("*");
            }
            Console.WriteLine();


            // b
            int c;
            Console.WriteLine("Nhập cạnh tam giác: ");
            c = int.Parse(Console.ReadLine());
            for (int i = 1; i <= c; i++)
            {
                for (int j = 1; j <= c - i; j++)
                    Console.Write(" ");
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    if (k == 1 || k == 2 * i - 1 || i == c)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }


            Console.ReadLine();

        }
    }
}
