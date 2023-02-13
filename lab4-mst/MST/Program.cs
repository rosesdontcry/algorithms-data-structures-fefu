using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MST
{
    internal abstract class Program
    {
        static void Prim()
        {
            int quantEdges = 0;
            int quantNodes = 0;
            
            StreamReader sr = new StreamReader(@"../../Graph.txt");
            var temp = sr.ReadLine().Split().Where(str => !string.IsNullOrWhiteSpace(str)).Select(str => int.Parse(str)).ToArray();
            quantEdges = temp[0];
            quantNodes = temp[1];

            var edges = new int[quantNodes,quantNodes];
            for (int i = 0; i < quantEdges; i++)
            {
                temp = sr.ReadLine().Split().Where(str => !string.IsNullOrWhiteSpace(str)).Select(str => int.Parse(str)).ToArray();
                edges[temp[0], temp[1]] = temp[2];
                edges[temp[1], temp[0]] = temp[2];
            }
            
            int weight = 0;
            var visited = new List<int> ();
            visited.Add(new Random().Next(0, quantNodes));

            var unvisited = new List<int> ();
            for (int i = 0; i < quantNodes; i++)
                unvisited.Add(i);;
            unvisited.RemoveAt(visited[0]);

            while (unvisited.Count > 0)
            {
                int node = 0;
                int min = 0;

                foreach (var i in visited)
                {
                    foreach (var j in unvisited)
                    {
                        if (edges[i, j] != 0 && (edges[i,j] < min || min == 0))
                        {
                            min = edges[i, j];
                            node = j;
                        }   
                    }
                }
                
                visited.Add(node);
                unvisited.Remove(node);
                weight += min;
            }

            Console.WriteLine($"Цикломатическое число: {quantEdges - quantNodes + 1}\n" +
                              $"Вес: {weight}");
        }
        
        struct Edge
        {
            public int Node1 { get; set; }
            public int Node2 { get; set; }
            public int Weight { get; set; }
        }

        static void Kruskal()
        {
            int quantNodes = 0;
            int quantEdges = 0;

            StreamReader sr = new StreamReader(@"../../Graph.txt");
            // ReSharper disable once PossibleNullReferenceException
            var temp = sr.ReadLine().Split().Where(str => !string.IsNullOrWhiteSpace(str)).Select(int.Parse).ToArray();
            quantEdges = temp[0];
            quantNodes = temp[1];
            
            Edge[] edges = new Edge[quantEdges];

            for (int j = 0; j < quantEdges; j++)
            {
                // ReSharper disable once PossibleNullReferenceException
                temp = sr.ReadLine().Split().Where(str => !string.IsNullOrWhiteSpace(str)).Select(int.Parse).ToArray();
                edges[j].Node1 = temp[0];
                edges[j].Node2 = temp[1];
                edges[j].Weight = temp[2];
                
                edges[j].Node1 = temp[1];
                edges[j].Node2 = temp[0];
                edges[j].Weight = temp[2];
            }

            var edgesOrder = from edge in edges orderby edge.Weight select edge;
            
            List<List<int>> list = new List<List<int>>(quantNodes);
            
            for (var i = 0; i < quantNodes; i++)
                list.Add(new List<int>());

            for (int i = 0; i < quantNodes; i++)
                list[i].Add(i);

            int weight = 0; 
            foreach(var edge in edgesOrder)
            {
                var temp1 = new List<int>();
                var temp2 = new List<int>();
                
                foreach(var l in list)
                    if(l.Contains(edge.Node1))
                    {
                         temp1 = l;
                         list.Remove(l);
                         break;
                    }
                
                foreach (var l in list)
                    if (l.Contains(edge.Node2))
                    {
                        temp2 = l;
                        list.Remove(l);
                        break;
                    }
                
                if (temp1.Count > 0 && temp2.Count > 0)
                {
                    list.Add(temp1.Union(temp2).ToList());
                    weight += edge.Weight;
                }
                else
                {
                    list.Add(temp1.Union(temp2).ToList());
                }

                if (list.Count == 1)
                    break;
            }
            
            Console.WriteLine($"Цикломатическое число: {quantEdges - quantNodes + 1}\n" +
                              $"Вес: {weight}");
        }
        
        public static void Main()
        {
            Console.CursorVisible = false;
            
            bool exit = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Алгоритм Прима\n" +
                                  "2. Алгоритм Краскала\n" +
                                  "3. Выход");
            
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Prim();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Kruskal();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        exit = false;
                        break;
                    default:
                        break;
                }
            } while (exit);
        }
    }
}
