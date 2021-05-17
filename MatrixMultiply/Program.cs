using System;
using System.Diagnostics;
using System.Threading;

namespace MatrixMultiply
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            Matrix matrix = new Matrix();
            matrix.SetValues(1000);

            stopwatch.Start();
            matrix.OrdinaryMultiply();
            stopwatch.Stop();

            Console.WriteLine("Обычное умножение: " + stopwatch.Elapsed);

            stopwatch.Restart();
            matrix.MultiplyParallel(4);
            stopwatch.Stop();

            Console.WriteLine("Параллельное умножение: " + stopwatch.Elapsed);
        }
    }
}
