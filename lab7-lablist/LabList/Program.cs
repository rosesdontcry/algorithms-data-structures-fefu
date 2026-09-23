using System;
using System.Collections.Generic;

//1 3 1 5 - 12 чисел из (-7; 30). Реализовать фунцию, которая вставлет элемент после первого нуля. 

namespace LabList
{
    internal class Program
    {
        static void PrintList(LinkedList<int> list)
        {
            foreach (var number in list)
            {
                Console.Write($"{number} ");
            }
            Console.Write("\n");   
        }
        
        public static void Main(string[] args)
        {
            var listNumbers = new LinkedList<int>();
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите {count} чисел из интервала (-7; 30):");
                Console.WriteLine($"{i + 1}/{count}");
                
                int a = 0;
                bool test = Int32.TryParse(Console.ReadLine(), out a);
                
                if (test & a > -7 & a < 30)
                {
                    listNumbers.AddLast(a);
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
                Console.WriteLine("Список:");
                PrintList(listNumbers);
                Console.WriteLine();
                Console.WriteLine("Список опираций над связанным списком:\n" +
                                  "1 - добавить элемент в список\n" +
                                  "2 - удалить элемент списока\n" +
                                  "3 - найти узел содержащий значение\n" +
                                  "4 - очистить список\n" +
                                  "5 - узнать существует ли элемент в списоке\n" +
                                  "6 - всавить элемент перед нулём\n" +
                                  "7 - выход\n");
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: 
                        Console.Clear();
                        Console.WriteLine("1 - в начало\n" +
                                          "2 - в конец\n" +
                                          "3 - после определенного элемента\n" +
                                          "4 - перед определенного элемента\n");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Console.WriteLine("Число:");
                                    int a;
                                    bool b = Int32.TryParse(Console.ReadLine(), out a);
                                    if (b)
                                    {
                                        listNumbers.AddFirst(a);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорреткное значение");
                                        Console.ReadKey();
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    Console.WriteLine("Число:");
                                    b = Int32.TryParse(Console.ReadLine(), out a);
                                    if (b)
                                    {
                                        listNumbers.AddLast(a);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорреткное значение");
                                        Console.ReadKey();
                                    }
                                    break;
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    Console.WriteLine("Число которое надо добавить:");
                                    b = Int32.TryParse(Console.ReadLine(), out a);
                                    if (b)
                                    {
                                        Console.WriteLine("Список");
                                        PrintList(listNumbers);
                                        Console.WriteLine("Значение элемента после котоорго надо добавить:");
                                        int c;
                                        bool d = Int32.TryParse(Console.ReadLine(), out c);
                                        if (d)
                                        {
                                            if (listNumbers.Contains(c))
                                            {

                                                listNumbers.AddAfter(listNumbers.Find(c), a);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого значения нет в списке");
                                                Console.ReadKey();
                                            }
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорреткное значение");
                                            Console.ReadKey();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорреткное значение");
                                        Console.ReadKey();
                                    }
                                    break;                                
                                case ConsoleKey.D4:
                                    Console.Clear();
                                    Console.WriteLine("Число которое надо добавить:");
                                    b = Int32.TryParse(Console.ReadLine(), out a);
                                    if (b)
                                    {
                                        Console.WriteLine("Список:");
                                        PrintList(listNumbers);
                                        Console.WriteLine("Значение элемента перед котоорым надо добавить:");
                                        int c;
                                        bool d = Int32.TryParse(Console.ReadLine(), out c);
                                        if (d)
                                        {
                                            if (listNumbers.Contains(c))
                                            {

                                                listNumbers.AddBefore(listNumbers.Find(c), a);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого значения нет в списке");
                                                Console.ReadKey();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорреткное значение");
                                            Console.ReadKey();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорреткное значение");
                                        Console.ReadKey();
                                    }
                                    break;
                                default:
                                    break;
                            }
                        
                        break;
                    case ConsoleKey.D2: 
                        Console.Clear();
                        Console.WriteLine("1 - первый\n" +
                                          "2 - последний\n" +
                                          "3 - определеннйы");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                                try
                                {
                                    listNumbers.RemoveFirst();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("\nСписок пуста");
                                    Console.ReadKey();
                                }
                                break;
                            case ConsoleKey.D2:
                                try
                                {
                                    listNumbers.RemoveLast();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("\nСписок пуста");
                                    Console.ReadKey();
                                }
                                break;
                            case ConsoleKey.D3:
                                try
                                {
                                    Console.WriteLine("Cпсок:");
                                    PrintList(listNumbers);
                                    Console.WriteLine("Значение:");
                                    int a;
                                    bool b = Int32.TryParse(Console.ReadLine(), out a);
                                    if (b)
                                    {
                                        listNumbers.Remove(a);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорреткное значение");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("\nСписок пуста");
                                    Console.ReadKey();
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("1 - первый узел\n" +
                                          "2 - последний узел");

                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                         
                                Console.WriteLine("\nCписок:");
                                PrintList(listNumbers);
                                Console.WriteLine("Значение:");
                                int temp;
                                bool boo = Int32.TryParse(Console.ReadLine(), out temp);
                                if (boo)
                                {
                                    Console.WriteLine("Узел:" + listNumbers.Find(temp));
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Некорректное значение");
                                    Console.ReadKey();
                                }
                                break;
                            case ConsoleKey.D2:
                                
                                Console.WriteLine("\nCписок:");
                                PrintList(listNumbers);
                                Console.WriteLine("Значение:");
                                temp = 0;
                                boo = Int32.TryParse(Console.ReadLine(), out temp);
                                if (boo)
                                {
                                    Console.WriteLine("Узел:" + listNumbers.FindLast(temp));
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Некорректное значение");
                                    Console.ReadKey();
                                }
                                break;
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        listNumbers.Clear();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        int a1;
                        Console.WriteLine("Число:");
                        bool b1 = Int32.TryParse(Console.ReadLine(), out a1);
                        if (b1)
                        {
                            bool b3 = listNumbers.Contains(a1);
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
                        Console.Clear();
                        bool ind = false;
                        foreach (var number in listNumbers)
                        {
                            if (number == 0)
                            {
                                ind = true;
                                Console.WriteLine("Число которое хотим добавить:");
                                int ele;
                                bool tf = Int32.TryParse(Console.ReadLine(), out ele);
                                if (tf)
                                {
                                    listNumbers.AddBefore( listNumbers.Find(0), ele);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректное значение");
                                    Console.ReadKey();
                                }
                            }
                        }
                        
                        if (!ind)
                        {
                            Console.WriteLine("В списке нет нулей");
                            Console.ReadKey();
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