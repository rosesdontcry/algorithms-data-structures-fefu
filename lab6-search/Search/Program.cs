using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Search
{
    internal abstract class Program
    {
 
        static int quant = 0;
        static int qunatComp = 0;
        struct Trade
        {
            public int Id { get; set; }
            public string ProductType { get; set; }
            public string Name { get; set; }
            public int Revenue { get; set; }

            public Trade(int id, string name, string productType, int revenue)
            {
                ProductType = productType;
                Name = name;
                Revenue = revenue;
                Id = id;
            }
        }
        
        static void IndexSequential(int[] array, int key)
        {
            int n = array.Length;
            int m = Convert.ToInt32(Math.Sqrt(n));
            int sizeIndexTable = Math.Abs((n - 1) / m) + 1;

            int[] kindex = new int[sizeIndexTable];
            int[] pindex = new int[sizeIndexTable];

            int low = 0 , high = 0;

            for (int i = m - 1, j = 0; j < sizeIndexTable - 1; i += m, j++)
            {
                kindex[j] = array[i];
                pindex[j] = i;
            }

            kindex[sizeIndexTable - 1] = array[array.Length - 1];
            pindex[sizeIndexTable - 1] = array.Length - 1;

            for (int i = 0; i < sizeIndexTable; i++)
            {
                if (kindex[i] >= key)
                {
                    high = pindex[i];
                    low = pindex[i] - m;
                    break;
                }
            }

            bool found = false;
            int id = 0;
            for (id = low + 1; id < high + 1; id++)
            {
                if (array[id] == key)
                {
                    found = true;
                    break;
                }
            }

            Console.WriteLine(found ? $"Я нашёл, штука {key} - {id} место" : $"не нашёл Sadge");
        }
        
        private static void Fibonacci(int[] array, int key)
        {

            quant++;
            
            int f = 0;
            int nextf = 1;
            
            while (array[nextf - 1] < key)
            {
                qunatComp++;
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
                    Console.SetCursorPosition(15, 0);
                    Console.WriteLine("Найдено: " + temp[0]);
                    Console.SetCursorPosition(15, 1);
                    Console.WriteLine("Количество рекурсий: " + quant);
                    Console.SetCursorPosition(15, 2);
                    Console.WriteLine("Количество итераций: " + qunatComp);
                    quant = 0;
                    qunatComp = 0;
                }
                else
                {
                    Console.WriteLine("Не нашёл " + key);
                    quant = 0;
                    qunatComp = 0;
                }
            }
            else
            {
                Fibonacci(temp, key);
            }
        }
        
        static void IndexSequential(Trade[] array, int key)
        {
            int n = array.Length;
            int m = Convert.ToInt32(Math.Sqrt(n));
            int sizeIndexTable = Math.Abs((n - 1) / m) + 1;

            int[] kindex = new int[sizeIndexTable];
            int[] pindex = new int[sizeIndexTable];

            int low = 0 , high = 0;

            for (int i = m - 1, j = 0; j < sizeIndexTable - 1; i += m, j++)
            {
                kindex[j] = array[i].Id;
                pindex[j] = i;
            }

            kindex[sizeIndexTable - 1] = array[array.Length - 1].Id;
            pindex[sizeIndexTable - 1] = array.Length - 1;

            for (int i = 0; i < sizeIndexTable; i++)
            {
                if (kindex[i] >= key)
                {
                    high = pindex[i];
                    low = pindex[i] - m;
                    break;
                }
            }

            bool found = false;
            int id = 0;
            for (id = low + 1; id < high + 1; id++)
            {
                if (array[id].Id == key)
                {
                    found = true;
                    break;
                }
            }

            Console.WriteLine(found ? $"Индексу {key} соответствует товар.\nТип: {array[id].ProductType}\nНаименование: {array[id].Name}\nЦена: {array[id].Revenue}" : $"Не нашёл");
        }
        
        private static void FillFile(string path, int quantity)
        {
            File.WriteAllText(path, string.Empty);
            
            StreamWriter sw = new StreamWriter(path, false);
            Random rnd = new Random();
            for (int i = 0; i < quantity; i++)
            {
                if (i == quantity - 1)
                {
                    sw.Write(rnd.Next(0, 1001));
                }
                else
                {
                    sw.Write(rnd.Next(0, 1001) + " ");
                }
            }

            sw.Close();
        }

        static int[] CreateArray(string path, int quantity)
        {
            FillFile(path, quantity);
            StreamReader sr = new StreamReader(path);
            string numbers = sr.ReadLine();
            sr.Close();
                  
            int[] array = numbers.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();

            return array;
        }
        
        static void QuickSort(int[] array, int ilo, int ihi)
        {
            int lo = ilo;
            int hi = ihi;
            int mid = array[(ilo + ihi) / 2];

            do
            {
                while (array[lo] < mid) lo++;
                while (array[hi] > mid) hi--;

                if (lo > hi)
                {
                    break;
                }
                if (array[lo] > array[hi])
                    (array[lo], array[hi]) = (array[hi], array[lo]);

                lo++;
                hi--;

            } while (lo <= hi);

            if (lo < ihi)
                QuickSort(array, lo, ihi);
            if (ilo < hi)
                QuickSort(array, ilo, hi);
        }
        
        static void Select()
        {
            Console.Clear();
            Console.WriteLine("1. Поиск Фибоначчи(числа)\n"+
                              "2. Индексно–последовательный поиск(записи)");
            
            switch(Console.ReadKey().Key)
            {
              case ConsoleKey.D1:
                  Console.Clear();
                  int quant = 0;
                  string path = "";
                  
                  Console.WriteLine("1. 100\n" +
                                    "2. 500");
                  switch (Console.ReadKey().Key)
                  {
                      case ConsoleKey.D1:
                          quant = 100;
                          path = @"../../100num.txt";
                          break;
                      case ConsoleKey.D2:
                          quant = 500;
                          path = @"../../500num.txt";
                          break;
                      default:
                          Select();
                          break;
                  }
                  
                  int[] array = new int[quant];
                  Array.Copy( CreateArray(path, quant),array, quant);

                  QuickSort(array, 0, array.Length - 1);
                  
                  do
                  {
                      Console.Clear();
                      Console.WriteLine("Число, которое нужно найти");

                      int key;
                      bool yes = int.TryParse(Console.ReadLine(), out key);
                      if (yes)
                      {
                          Console.Clear();
                  
                          foreach (var i in array)
                          {
                              Console.WriteLine(i);
                          }
                          Console.SetCursorPosition(15, 0);
                          Console.ForegroundColor = ConsoleColor.Blue;
                          Fibonacci(array, key);
                          Console.ResetColor();
                      }
                      else
                      {
                          Console.Clear();
                          Console.WriteLine("Ошибка ввода");    
                      }
                      
                  } while (Console.ReadKey().Key != ConsoleKey.Escape);
                  
                  Select();
                  break;
              case ConsoleKey.D2:
                  Console.Clear();
                  string all = "";
                  int count = 0;

                  var sr = new StreamReader(@"..\..\Data.txt");
                  while ((sr.ReadLine()) != null)
                  {
                      count++;
                  }
                  sr.Close();
                  
                  var textInArray = new string[count]; 
                  var structsArray = new Trade[count / 4];
                  
                  var sr2 = new StreamReader(@"..\..\Data.txt");
                  for (int i = 0; i < count; i++)
                  {
                      textInArray[i] = sr2.ReadLine();
                  }
                  sr2.Close();

                  for (int i = 0, j = 0; i < count / 4; i ++, j += 4)
                  {
                      structsArray[i] = new Trade(int.Parse(textInArray[j]), textInArray[j+2], textInArray[j+1], int.Parse(textInArray[j+3]));
                  }

                  do
                  {
                      Console.Clear();
                      Console.WriteLine("Индекс продукта, которыей нужжно найти");
                      int key2 = 0;
                      string key2Input = Console.ReadLine();
                      while (!int.TryParse(key2Input, out key2))
                      {
                          Console.Clear();
                          Console.Write("Ошибка ввода. Попробуйте снова:\n");
                          key2Input = Console.ReadLine();
                      }

                      Console.Clear();
                      Console.SetCursorPosition(0, 0);
                      Console.Write("Индекс");
                      Console.SetCursorPosition(10, 0);
                      Console.Write("Тип товара");
                      Console.SetCursorPosition(50, 0);
                      Console.Write("Наименования товара");
                      Console.SetCursorPosition(85, 0);
                      Console.Write("Цена");

                      for (int i = 0; i < structsArray.Length; i++)
                      {
                          Console.SetCursorPosition(0, i + 1);
                          Console.Write(structsArray[i].Id);
                          Console.SetCursorPosition(10, i + 1);
                          Console.Write(structsArray[i].ProductType);
                          Console.SetCursorPosition(50, i + 1);
                          Console.Write(structsArray[i].Name);
                          Console.SetCursorPosition(85, i + 1);
                          Console.Write(structsArray[i].Revenue);

                      }
                      
                      Console.SetCursorPosition(0, structsArray.Length + 2);
                      Console.ForegroundColor = ConsoleColor.Blue;
                      IndexSequential(structsArray, key2);
                      Console.ResetColor();
                      
                  } while (Console.ReadKey().Key != ConsoleKey.Escape);

                  break;
              default:
                  Select();
                  break;
            }
        }
        
        public static void Main()
        {
            Console.CursorVisible = false;
            Select();
           
            Console.ReadKey();
        }
    }
}
