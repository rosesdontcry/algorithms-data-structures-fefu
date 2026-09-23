using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciSearch
{
    internal abstract  class Program
    {
        private static void Fibonacci(int[] array, int key)
        {
            int f = 0;
            int nextf = 1;
            
            while (array[nextf - 1] < key)
            {
                (f, nextf) = (nextf, f + nextf);
                if (nextf > array.Length)
                {
                    nextf = array.Length;
                }
            }

            int[] temp = new int[nextf - f];

            for (int i = f, j = 0; i < nextf; i++, j++)
            {
                temp[j] = array[i];
            }

            if (temp.Length == 1)
            {
                if (key == temp[0])
                {
                    Console.WriteLine("Найдено:" + temp[0]);
                }
                else
                {
                    Console.WriteLine("Не нашёл");
                }
            }
            else
            {
                Fibonacci(temp, key);
            }
        }

        private static void IndexSequential(int[] array, int key)
        {
            int sizeIndex = 4;
            int[] pindex = new int[sizeIndex];
            int[] kindex = new int[sizeIndex];
            int low, high;

            
            
        } 
        
        public static void Main()
        {
            Fibonacci(new int[]{2,5,6,9,12,16,18,20,21,28,32,39,44,46,51,55,60}, 21);
            Console.ReadKey();
        }
    }
}