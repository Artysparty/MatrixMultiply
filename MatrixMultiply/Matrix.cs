using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixMultiply
{
    public class Matrix
    {
        public int[,] firstMatrix;
        public int[,] secondMatrix;
        public int[,] rezultMatrix;
        public int n;

        public void SetValues(int n)
        {
            this.n = n;
            firstMatrix = new int[n, n];
            secondMatrix = new int[n, n];
            rezultMatrix = new int[n, n];

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    firstMatrix[i, j] = rand.Next(100);
                    secondMatrix[i, j] = rand.Next(100);
                }
            }
        }

        public void MultiplyParallel(int k)
        {
            int intervalLength = n / k;

            Thread[] threads = new Thread[k];

            for (int i = 0; i < k; i++)
            {
                Range range = new Range(i * intervalLength, i + 1 * intervalLength);
                threads[i] = new Thread(new ParameterizedThreadStart(FindElems));
                threads[i].Start(range);
            }

            for (int i = 0; i < k; i++)
            {
                threads[i].Join();
            }
        }


        public void OrdinaryMultiply()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        rezultMatrix[i, j] = firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
        }

        public void FindElems(object range)
        {
            Range r = (Range)range;

            for (int i = r.start; i < r.end; i++)
            {
                for (int j = r.start; j < r.end; j++)
                {
                    for (int k = r.start; k < r.end; k++)
                    {
                        rezultMatrix[i, j] = firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
        }
    }
}
