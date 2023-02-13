using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace DifferentSortings
{
    internal class Program
    {
        public static int qunt = 0;
        private static void FillFile(string path, int quantity)
        {
            StreamWriter sw = new StreamWriter(path, false);
            Random rnd = new Random();
            for (int i = 0; i < quantity; i++)
            {
                if (i == quantity - 1)
                {
                    sw.Write(rnd.Next(-10000, 10001));
                }
                else
                {
                    sw.Write(rnd.Next(-10000, 10001) + " ");
                }
            }

            sw.Close();
        }
        
        private static int[] CreateArray(string path)   
        {
            StreamReader sr = new StreamReader(path);
            string numbers = sr.ReadLine();
            sr.Close();

            var array = numbers.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            return array;
        }
        
        private static void WriteArray(int[] array)
        {
            foreach (var i in array)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();
        }

        private static int[] SelectSizeArrayOrStructs(ref int quant)
        {
            int[] originalArray = new int[]{};
            
            Console.Clear();
            Console.WriteLine("\tКоличество чисел:\n" +
                              "1. 500\n" +
                              "2. 1000\n" +
                              "3. 5000\n" +
                              "4. Гномья сортировка записей ");
                
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    File.WriteAllText(@"..\..\Data\500num.txt", string.Empty);
                    FillFile(@"..\..\Data\500num.txt", 500);
                    quant = 500;
                    originalArray = CreateArray(@"..\..\Data\500num.txt");
                    break;
                case ConsoleKey.D2:
                    File.WriteAllText(@"..\..\Data\1000num.txt", string.Empty);
                    FillFile(@"..\..\Data\1000num.txt", 1000);
                    quant = 1000;
                    originalArray = CreateArray(@"..\..\Data\1000num.txt");
                    break;
                case ConsoleKey.D3:
                    File.WriteAllText(@"..\..\Data\5000num.txt", string.Empty);
                    FillFile(@"..\..\Data\5000num.txt", 5000);
                    quant = 5000;
                    originalArray = CreateArray(@"..\..\Data\5000num.txt");
                    break;
                case ConsoleKey.D4:
                    int count = 0;
                    
                    var sr = new StreamReader(@"..\..\Data\Datat.txt");
                    while ((sr.ReadLine()) != null)
                    {
                        count++;
                    }
                    sr.Close();

                    var textInArray = new string[count]; 
                    var structsArray = new Game[count / 3];
                    
                    var sr2 = new StreamReader(@"..\..\Data\Datat.txt");
                    for (int i = 0; i < count; i++)
                    {
                        textInArray[i] = sr2.ReadLine();
                    }
                    sr2.Close();
                    
                    for (int i = 0, j = 0; i < count; i += 3, j ++)
                    {
                       structsArray[j] = new Game(textInArray[i], textInArray[i+1], int.Parse(textInArray[i+2]));
                    }
                    Sortings.GnomeSort(structsArray);

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Название игры");
                    Console.SetCursorPosition(40, 0);
                    Console.Write("Жанр");
                    Console.SetCursorPosition(80, 0);
                    Console.Write("Рейтинг");
                    Console.ResetColor();
                    
                    for (int i = count / 3; i > 0; i--)
                    {
                        Console.SetCursorPosition(0, count / 3 - i + 1);
                        Console.Write(structsArray[i - 1].Name);
                        Console.SetCursorPosition(40, count / 3 - i + 1);
                        Console.Write(structsArray[i - 1].GameType);
                        Console.SetCursorPosition(80, count / 3 - i + 1);
                        Console.Write(structsArray[i - 1].Rating);
                        
                    }

                    
                    Console.ReadKey();
                    Environment.Exit(0);
                    SelectSizeArrayOrStructs(ref quant);
                    
                    break;
                default:
                    SelectSizeArrayOrStructs(ref quant);
                    break;
            }
            return originalArray;
        }
        
        static void WriteInFile(int swap, int comparison, object time)
        {
            StreamWriter sw = new StreamWriter(@"..\..\Data\characteristics.txt", true);
            
            sw.Write($"{comparison} {swap} {time} \n");
            sw.Close();
        }
        
        private static void Refresh(int[] originalArray, int[] array, ref int counterSwap, ref int counterComparison)
        {
            Array.Copy(originalArray, array, originalArray.Length);
            counterComparison = 0;
            counterSwap = 0;
        }
        
        private static void Refresh(int[] originalArray, int[] array)
        {
            Array.Copy(originalArray, array, originalArray.Length);
        }
        

        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            
            int[] originalArray = SelectSizeArrayOrStructs(ref qunt);
            int[] fakeArray = new int[originalArray.Length];

            Array.Copy(originalArray, fakeArray, originalArray.Length);
            
            int counterSwap = 0;
            int counterСomparison = 0;

            bool exit = true; 
            while(exit)
            {
                Console.Clear();
                Console.WriteLine("\tОпции:\n" +
                                  "1. Сортировка простыми вставками\n" +
                                  "2. Сортировка простым обменом\n" +
                                  "3. Сортировка простым выбором\n" +
                                  "4. Гномья\n" +
                                  "5. Быстрая сортировка\n" +
                                  "6. Характеристики сортировок\n" +
                                  "7. Выход\n");
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Refresh(originalArray, fakeArray);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tСортировка простыми вставками\nБыло:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        
                        Sortings.InsertionSort(fakeArray);
                        
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nСтало:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Refresh(originalArray, fakeArray);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tСортировка простыми обменом\nБыло:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        
                        Sortings.BubbleSort(fakeArray);
                        
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nСтало:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Refresh(originalArray, fakeArray);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tСортировка простым выбором\nБыло:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        
                        Sortings.SelectionSort(fakeArray);
                        
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nСтало:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Refresh(originalArray, fakeArray);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tГномья\nБыло:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        
                        Sortings.GnomeSort(fakeArray);
                        
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nСтало:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Refresh(originalArray, fakeArray);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tБыстрая сортировка\nБыло:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        
                        Sortings.QuickSort(fakeArray, 0, fakeArray.Length - 1);
                        
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nСтало:");
                        Console.ResetColor();
                        WriteArray(fakeArray);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        File.WriteAllText(@"..\..\Data\characteristics.txt", string.Empty);
                        
                        var time = new Stopwatch();
                        time.Start();
                        Sortings.InsertionSort(fakeArray, ref counterSwap, ref counterСomparison);
                        time.Stop();

                        WriteInFile(counterSwap, counterСomparison, time.ElapsedTicks);
                        Refresh(originalArray, fakeArray, ref counterSwap, ref counterСomparison);
                        
                        time.Restart();
                        time.Start();
                        Sortings.BubbleSort(fakeArray, ref counterSwap, ref counterСomparison);
                        time.Stop();

                        WriteInFile(counterSwap, counterСomparison, time.ElapsedTicks);
                        Refresh(originalArray, fakeArray, ref counterSwap, ref counterСomparison);
                        
                        time.Restart();
                        time.Start();
                        Sortings.SelectionSort(fakeArray, ref counterSwap, ref counterСomparison);
                        time.Stop();

                        WriteInFile(counterSwap, counterСomparison, time.ElapsedTicks);
                        Refresh(originalArray, fakeArray, ref counterSwap, ref counterСomparison);

                        time.Restart();
                        time.Start();
                        Sortings.GnomeSort(fakeArray, ref counterSwap, ref counterСomparison);
                        time.Stop();

                        WriteInFile(counterSwap, counterСomparison, time.ElapsedTicks);
                        Refresh(originalArray, fakeArray, ref counterSwap, ref counterСomparison);

                        time.Restart();
                        time.Start();
                        Sortings.QuickSort(fakeArray, 0, fakeArray.Length - 1, ref counterSwap, ref counterСomparison);
                        time.Stop();

                        WriteInFile(counterSwap, counterСomparison, time.ElapsedTicks);
                        Refresh(originalArray, fakeArray, ref counterSwap, ref counterСomparison);

                        Table.Print();
                        
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        exit = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }       
}
