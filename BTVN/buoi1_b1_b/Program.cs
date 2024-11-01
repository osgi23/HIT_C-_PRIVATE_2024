using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Buoi1_bai1b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double A = double.Parse(Console.ReadLine());
            double t = double.Parse(Console.ReadLine());
            double omega = double.Parse(Console.ReadLine()) * Math.PI;

            double T = 2 * Math.PI / omega;
            double solve = 0;
            int allchuki = (int)(t / T);
            /// Tinh gia tri cua cac chu ky da chay het
            solve += 4 * A * allchuki;
            /// Tinh gia tri cua cac chu ki T / 2, T / 4.
            double tg_remaining = 0;
            for (int i = 2; i <= 4; i += 2)
            {
                tg_remaining = t - allchuki * T;
                double tmp = (int)(tg_remaining / (T / i));
                solve += Math.Abs((4 / i) * A * tmp);
                tg_remaining -= tmp * T / i;
                Console.WriteLine(tg_remaining);
            }
            solve += Math.Abs(A - Math.Cos(2 * Math.PI * (tg_remaining / T)) * A);

            Console.WriteLine($"Quãng đường mà vật đi được sau {t} giây là: {solve} cm");
            Console.ReadKey();
        }
    }
}
