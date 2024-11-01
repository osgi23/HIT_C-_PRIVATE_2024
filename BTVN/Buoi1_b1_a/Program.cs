using System;
using System.CodeDom;

namespace BTVN_Buoi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bai 1 - a
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double t = double.Parse(Console.ReadLine());

            double A = 9;
            double T = 0.4;
            double solve = 0;
            int allchuki = (int)(t / T);
            /// Tinh gia tri cua cac chu ky chay het
            solve += 4 * A * allchuki;
            /// Tinh gia tri cua cac chu ky chua chay het
            solve += A + A - Math.Cos(Math.PI / 8) * A;
            Console.WriteLine($"Quãng đường mà vật đi được sau {t} giây là: {solve} cm");
            Console.ReadKey();
        }
    }
}
