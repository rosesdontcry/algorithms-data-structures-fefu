using System;
using System.IO;

namespace DifferentSortings
{
    public abstract class Table
    {
        public static void Print()
        {
            StreamReader sr = new StreamReader(@"..\..\Data\characteristics.txt");

            string[] data = (sr.ReadLine() + sr.ReadLine() + sr.ReadLine() + sr.ReadLine() + sr.ReadLine()).Split(' ');
            
            sr.Close();
            
            Title();
            Line("Сортировка простыми вставками", Convert.ToString(DifferentSortings.Program.qunt), data[0], data[1], data[2]);
            Line("Сортировка простым обменом", Convert.ToString(DifferentSortings.Program.qunt), data[3], data[4], data[5]);
            Line("Сортировка простым выбором", Convert.ToString(DifferentSortings.Program.qunt), data[6], data[7], data[8]);
            Line("Гномья", Convert.ToString(DifferentSortings.Program.qunt), data[9], data[10], data[11]);
            Line("Быстрая сортировка", Convert.ToString(DifferentSortings.Program.qunt), data[12], data[13], data[14]);
            
        }
        private static void Title()
        {
            Console.Write(
                $"{new string('-', 114)}\n" +
                $"|{new string(' ', 7)}Вид сортировки{new string(' ', 8)}|Количество элементов|Количество сравнений|Количество перестановок|Время выполнения|\n" +
                $"{new string('-', 114)}\n");
        }
        private static void Line(string name, string quantity, string comparison, string swap, string time)
        {
            Console.Write(
                $"|{name}{new string(' ', 29 - name.Length)}" +
                
                $"|{quantity}{new string(' ', 20 - quantity.Length)}" +
                
                $"|{comparison}{new string(' ', 20 - comparison.Length)}" +
                
                $"|{swap}{new string(' ', 23 - swap.Length)}" +
                
                $"|{time}{new string(' ', 16 - time.Length)}|\n" +
                
                $"{new string('-', 114)}\n"
                );
        }
    }
}