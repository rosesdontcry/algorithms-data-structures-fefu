using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dect
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string text;
            StreamReader sr = new StreamReader(@"../../Input.txt");
            text = sr.ReadLine();
            sr.Close();
            
            text = text.ToLower();

            var separators = new char[] {'(', ')', ',', '.', '<', '>','"','«', '»', '—', ' '};
            var listWords = new List<string>(text.Split(separators, StringSplitOptions.RemoveEmptyEntries));

            bool exit = true;
            while (exit)
            {
                foreach (var word in listWords)
                {
                    if (word.Length == 1)
                    {
                        listWords.Remove(word);
                        break;
                    }

                    if (word == listWords[listWords.Count-1])
                    {
                        exit = false;
                    }
                }
            }

            listWords.Sort();

            StreamWriter wr = new StreamWriter(@"../../Output.txt", false);
            wr.WriteLine("Количество слов: " + listWords.Count + "\n");

            int count = 1; 
                for (int i = 1; i < listWords.Count; i++)
                {
                    if (listWords[i] != listWords[i - 1])
                    {
                        wr.WriteLine(listWords[i - 1] + " - " + count);
                        count = 1;
                    }
                    else 
                    {
                        count++;
                    }
                }

                if (listWords[listWords.Count - 1] != listWords[listWords.Count - 2])
                {
                    wr.WriteLine(listWords[listWords.Count-1] + " - " + 1);
                }
                
            wr.Close();
        }
    }
}