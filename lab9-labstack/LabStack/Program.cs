using System;
using System.Collections.Generic;
using System.Text;

namespace LabStack
{
    internal class Program
    {
        private static void WriteStack(Stack<string> words)
        {
            Console.WriteLine();
            foreach (var i in words)
            {
                Console.WriteLine(i + " ");
            }
        }

        private static Stack<string> AddWordInStack(Stack<string> words)
        {
            string str = Console.ReadLine();
            int ts = 0;
            foreach (var ch in str)
            {
                var alphafit = new List<char>("qwertyuiopasdfghjklzxcvbnm");

                if (!alphafit.Contains(ch))
                {
                    Console.SetCursorPosition(0, 2);
                    for (int g = 0; g < 222; g++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("Слово дожно состоять только из букв");
                    break;
                }
                else
                {
                    Console.Clear();
                    ts ++;
                    if(ts == str.Length)
                        words.Push(str);
                }
            }

            return words;
        }
        
        public static void Main(string[] args)
        {
            Stack<string> words = new Stack<string>();
            int count = 2;
            
            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Заполните стек");
                Console.WriteLine((i) + "/" + count);

                int need = words.Count;
                AddWordInStack(words);
                if (need != words.Count - 1)
                    i--;

            }
            
            Console.Clear();
            Console.CursorVisible = false;
            
            bool exit = true;
            while (exit)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Слова в стеке:");
                WriteStack(words);
                Console.WriteLine("\nВыберитать операцию над стеком: \n" +
                                  "1 - удалить все слова до слова с нечет кол-вом букв \n" +
                                  "2 - добавить элемент \n" +
                                  "3 - удалить элемент \n" +
                                  "4 - увидеть последний элемент \n" +
                                  "5 - узнать количество элементов стека \n" +
                                  "6 - очистить стек \n" +
                                  "7 - выход \n");
                
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Слово:");
                        AddWordInStack(words); 
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        if(words.Count != 0)
                            words.Pop();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.SetCursorPosition(0, 12+count);
                        if(words.Count != 0)
                            Console.WriteLine(words.Peek());
                        else 
                            Console.WriteLine("Стек пуст");
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.SetCursorPosition(0, 12 + words.Count);
                        Console.WriteLine(words.Count);
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        words.Clear();
                        break;
                    case ConsoleKey.D1:
                        Console.Clear();
                        if (words.Count > 0)
                        {
                            while (true)
                            {
                                if (words.Peek().Length % 2 == 0)
                                {
                                    words.Pop();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        break;
                    case ConsoleKey.D7:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
                
            } 
        }
    }
}