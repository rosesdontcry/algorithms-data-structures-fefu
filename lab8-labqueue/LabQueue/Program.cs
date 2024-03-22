using System;
using System.Collections.Generic;

namespace LabQueue
{
    internal class Program
    {
        private static void PrintQueue(Queue<int> numbers)
        {
            for (int i = numbers.Count - 1; i > -1; i--)
            {
                Console.Write($"{numbers.ToArray()[i]} ");
            }
            Console.WriteLine("\n");
        }
        
        public static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>();
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"Введите 11 чисел из интервала (-7; 30):");
                Console.WriteLine($"{i + 1}/11");
                
                int a = 0;
                bool test = Int32.TryParse(Console.ReadLine(), out a);
                if (test & a > -7 & a < 30)
                {
                    numbers.Enqueue(a);
                    Console.Clear();
                       
                }
                else
                {
                    i--;
                    Console.WriteLine("Некорректное значение");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            
            Console.CursorVisible = false;
            bool exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Oчередь:");
                PrintQueue(numbers);
                Console.WriteLine("Список операций над очередью:\n" +
                                  "1 - добавить элемент в очередь\n" +
                                  "2 - удалить первый эдемент очереди\n" +
                                  "3 - показать первый элемент очереди\n" +
                                  "4 - очистить очередь\n" +
                                  "5 - узнать существует ли элемент в очереди\n" +
                                  "6 - скопировать и вставить минимальный элемент из очереди\n" +
                                  "7 - выход\n");
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Число:");
                        int a;
                        bool b = Int32.TryParse(Console.ReadLine(), out a);
                        if (b)
                        {
                            numbers.Enqueue(a);
                        }
                        else
                        {
                            Console.WriteLine("Некорреткное значение");
                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        try
                        {
                            numbers.Dequeue();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Очередь пуста");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Peek());
                            Console.WriteLine("\nНажмите любую кноку");
                            Console.ReadKey();
                        }

                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        numbers.Clear();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        int a1;
                        Console.WriteLine("Число:");
                        bool b1 = Int32.TryParse(Console.ReadLine(), out a1);
                        if (b1)
                        {
                            bool b3 = numbers.Contains(a1);
                            if (b3)
                            {
                                Console.WriteLine("Содержит");
                                Console.WriteLine("\nНажмите любую кноку");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Не содержит");
                                Console.WriteLine("\nНажмите любую кноку");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорреткное значение");
                            Console.ReadKey();
                        }break;
                    case ConsoleKey.D6:
                        if (numbers.Count > 0)
                        {
                            int min = numbers.Peek();
                            foreach (var i in numbers)
                            {
                                if (i < min) min = i;
                            }

                            numbers.Enqueue(min);
                        }
                        break;
                    case ConsoleKey.D7:
                        exit = false;
                        break;
                }
            }
        }
    }
} 
