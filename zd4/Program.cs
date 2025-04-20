using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zd4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Исходные данные
            double lambda = 4.0;
            double t = 17.0 / 60;
            int maxLen = 5;

            double mu = 1 / t;
            double rho = lambda / mu;
            double P0;
            if (Math.Abs(rho - 1) < 1e-6) // почти 1 (1e-6 = 0,000001)
            {
                P0 = 1 / (maxLen + 2);
            }
            else
            {
                P0 = (1 - rho) / (1 - Math.Pow(rho, maxLen + 2));
            }
            double PR = Math.Pow(rho, maxLen + 1) * P0;
            double Q = 1 - PR;
            double A = lambda * Q;
            double L_que;
            if (Math.Abs(rho - 1) < 1e-6)
            {
                L_que = (maxLen + 1) * maxLen / (2 * (maxLen + 2));
            }
            else
            {
                L_que = Math.Pow(rho, 2) * (1 -Math.Pow(rho, maxLen) * (maxLen + 1 - maxLen * rho)) / 
                    ((1- rho)* (1- Math.Pow(rho, maxLen +2)));
            }
            double L_ser = rho * Q;
            double L_sys = L_que + L_ser;
            double W_que = L_que / A;
            double W_sys = W_que + (1 / mu);

            Console.WriteLine($"Интенсивность обслуживания: {mu:F4} машин/час");
            Console.WriteLine($"Коэффициент загрузки: {rho:F4}");
            Console.WriteLine($"Вероятность простоя: {P0:F4}");
            Console.WriteLine($"Вероятность отказа: {PR:F4}");
            Console.WriteLine($"Относительная пропускная способность: {Q:F4}");
            Console.WriteLine($"Абсолютная пропускная способность: {A:F4}");
            Console.WriteLine($"Среднее число машин в очереди: {L_que:F4}");
            Console.WriteLine($"Среднее число машин на обслуживании: {L_ser:F4}");
            Console.WriteLine($"Среднее число машин в системе: {L_sys:F4}");
            Console.WriteLine($"Среднее время ожидания в очереди: {W_que:F4} часов");
            Console.WriteLine($"Среднее время ожидания в системе: {W_sys:F4} часов");
        }   
    }
}

