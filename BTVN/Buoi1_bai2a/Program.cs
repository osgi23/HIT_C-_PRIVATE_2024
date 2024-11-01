using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi1_bai2a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            /// Bai 2
            // a
            int v0 = 20;
            double phi = 30;
            double v0x = v0 * Math.Cos(Math.PI * phi / 180);
            double v0y = v0 * Math.Sin(Math.PI * phi / 180);
            Console.WriteLine($"Giá trị của v0x là : {v0x}");
            Console.WriteLine($"Giá trị của v0y là : {v0y}");

            // b
            double g = 9.8;
            double t = v0y / g;
            Console.WriteLine("Giá trị của thời gian lên đến điểm cao nhất là: {0}", t);

            // c
            double H = v0y * t - 1/2 * g * Math.Pow(t, 2);
            Console.WriteLine($"Giá trị của chiều cao cực đại mà vật đạt được là: {H}");

            // d
            // thoi gian  len xuong nhu nhau nen tgian tong la 2 * t
            double T = 2 * t;
            double R = v0x * T;
            Console.WriteLine("Giá trị của quãng đường vật đã đi khi trở lại mặt đất là: {0}", R);
            Console.ReadKey();
            
        }
    }
}
