using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    internal class Program
    {
	    static void OptopnAddM(ref Data data)
		{
			data.Print();
			
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.SetCursorPosition(50, 0);
            Console.WriteLine("Введите элемент который хотите добавить");
            Console.SetCursorPosition(50, 1);
            string str = Console.ReadLine();
            Divisions.Add(ref data, str);

            StreamWriter sw = new StreamWriter("Data.txt", true);
            sw.WriteLine(str);
            sw.Close();
            Console.ResetColor();
		}
		
		static void OptiondDeleteM(ref Data data)
		{
			data.Print();
			
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.SetCursorPosition(50, 0);
			Console.WriteLine( "Введите элемент который хотите удалить");
			
			Console.SetCursorPosition(50, 1);
			string tmpstr = Console.ReadLine();
			
			Console.SetCursorPosition(50, 1);
			if (Divisions.CanDelete(ref data,tmpstr)) 
				Console.WriteLine("Элемент удалён              ");
			else 
				Console.WriteLine("Такого элемента нет в хеш-таблице");
			Console.ResetColor();
			Console.ReadKey();
		}

		static void OptionSearchM(ref Data data)
		{
			data.Print();
			
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.SetCursorPosition(50, 0);
			Console.WriteLine("Введите слово которое хотите найти");
			Console.SetCursorPosition(50, 1);
			string str = Console.ReadLine();
			Console.SetCursorPosition(50, 1);
			if (Divisions.Search(ref data, str) == -1) 
				Console.WriteLine("Неверно введены данные");
			else 
				Console.WriteLine(Divisions.Search(ref data, str) + ". " + str);
			Console.ResetColor();
			Console.ReadKey();
		}
		
		static void OptionAddD(ref Data data)
		{
			data.Print();
			
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.SetCursorPosition(50, 0);
			Console.WriteLine("Введите элемент который хотите добавить");
			Console.SetCursorPosition(50, 1);
			string str = Console.ReadLine();
			Multiplications.Add(ref data, str);
			Console.ResetColor();
			
			StreamWriter sw = new StreamWriter("Data.txt", true);
			sw.WriteLine(str);
			sw.Close();
			Console.ResetColor();
		}
		
		static void OptionDeleteD(ref Data data)
		{
			data.Print();
			
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.SetCursorPosition(50, 0);
			Console.WriteLine("Введите элемент который хотите удалить");
			
			Console.SetCursorPosition(50, 1);
			string tmpstr = Console.ReadLine();
			
			Console.SetCursorPosition(50, 1);
			if (Multiplications.CanDelete(ref data, tmpstr)) 
				Console.WriteLine("Элемент удалён        ");
			else 
				Console.WriteLine("Такого элемента нет в хеш-таблице");
			Console.ResetColor();
			Console.ReadKey();

		}
		
		static void OptionSearchD(ref Data data)
		{
			data.Print();
			
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.SetCursorPosition(50, 0);
			Console.WriteLine("Введите слово которое хотите найти");
			Console.SetCursorPosition(50, 1);
			string str = Console.ReadLine();
			Console.SetCursorPosition(50, 1);
			if (Multiplications.Search(ref data, str) == -1) 
				Console.WriteLine("Неверно введены данные");
			else 
				Console.WriteLine(Multiplications.Search(ref data, str) + ". " + str);
			Console.ResetColor();
			Console.ReadKey();
		}
		
		static void OptionsD()
		{
			Data data = new Data(99);
			StreamReader stream = new StreamReader("Data.txt");
			string str;
			while((str = stream.ReadLine())!=null)
			{
				Divisions.Add(ref data, str);
			}
			stream.Close();

			bool exit = true;
			do
			{
				Console.Clear();
				data.Print();

				Console.ForegroundColor = ConsoleColor.Blue;
				Console.SetCursorPosition(80, 0);
				Console.WriteLine("Метод деления");
				Console.SetCursorPosition(80, 1);
				Console.WriteLine("1. Добавить элемент");
				Console.SetCursorPosition(80, 2);
				Console.WriteLine("2. Удалить элемент");
				Console.SetCursorPosition(80, 3);
				Console.WriteLine("3. Найти по слову");
				Console.SetCursorPosition(80, 4);
				Console.WriteLine("Ecs. Назад");
				Console.ResetColor();

				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.D1:
						Console.Clear();
						OptopnAddM(ref data);
						break;
					case ConsoleKey.D2:
						Console.Clear();
						OptiondDeleteM(ref data);
						break;
					case ConsoleKey.D3:
						Console.Clear();
						OptionSearchM(ref data);
						break;
					case ConsoleKey.Escape:
						exit = false;
						break;
					default:
						break;
				}
			}while (exit);
		}
		
		static void OptionM()
		{
			Data data = new Data(99);
			StreamReader stream = new StreamReader("Data.txt");
			
			string str;
			
			while ((str = stream.ReadLine()) != null)
			{
				Multiplications.Add(ref data, str);
			}
			stream.Close();
			
			bool exit = true;
			do
			{
				Console.Clear();
				
				data.Print();

				Console.ForegroundColor = ConsoleColor.Blue;
				Console.SetCursorPosition(80, 0);
				Console.WriteLine("Метод умножения");
				Console.SetCursorPosition(80, 1);
				Console.WriteLine("1. Добавить элемент");
				Console.SetCursorPosition(80, 2);
				Console.WriteLine("2. Удалить элемент");
				Console.SetCursorPosition(80, 3);
				Console.WriteLine("3. Найти по слову");
				Console.SetCursorPosition(80, 4);
				Console.WriteLine("Ecs. Назад");
				Console.ResetColor();
				
				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.D1:
						Console.Clear();
						OptionAddD(ref data);
						break;
					case ConsoleKey.D2:
						Console.Clear();
						OptionDeleteD(ref data);
						break;
					case ConsoleKey.D3:
						Console.Clear();
						OptionSearchD(ref data);
						break;
					case ConsoleKey.Escape:
						exit = false;
						break;
					default:
						break;
				}
			}while(exit);
		}
		
		internal static void Main(string[] args)
		{
			Console.CursorVisible = false;
			bool exit = true;
			do
			{
				Console.WriteLine("1. Метод деления\n" +
				                  "2. Метод умножения\n" +
				                  "Esc. Завршить работу");
				
				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.D1:
						Console.Clear();
                        OptionsD(); 
                        break;
					case ConsoleKey.D2:
						Console.Clear();
						OptionM(); 
						break;
					case ConsoleKey.Escape:
						exit = false;
						break;
					default:
						break;
				}
				Console.Clear();
			}while(exit);
        }
	}
}
