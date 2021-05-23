using System;
using System.Collections.Generic;
using System.Linq;

namespace Weighted_Directed_Graph
{
    class Test
    {

        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public Test(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Graph<int> graph = new Graph<int>();

            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            graph.AddVertex(9);
            graph.AddVertex(10);
            graph.AddVertex(11);
            graph.AddEdge(1, 2, 6);
            //graph.AddEdge(2, 4, 5);
            graph.AddEdge(4, 5, 9);
            graph.AddEdge(4, 9, 5);
            graph.AddEdge(5, 6, 7);
            graph.AddEdge(5, 7, 2);
            graph.AddEdge(7, 5, 5);
            graph.AddEdge(7, 3, 8);
            graph.AddEdge(2, 8, 13);
            graph.AddEdge(8, 7, 3);
            graph.AddEdge(2, 4, 1);
            graph.AddEdge(9, 10, 1);
            graph.AddEdge(10, 7, 1);
            graph.AddEdge(4, 3, 1);
            graph.AddEdge(3, 5, 2);

            List<Vertex<int>> list = Dijkstra<int>.Dijkstra2(6, 1, graph);

            ;

            Comparer<(Vertex<int>, double)> c = Comparer<(Vertex<int>, double)>.Create((x,y)=> x.Item2.CompareTo(y.Item2));


            ////List<int> list = new List<int>() { 2, 1, 23, -123, 0 };
            ////var result = list.Where(x => x > 1).ToList();
            //List<Test> myList = new List<Test>();

            //myList.Add(new Test(3, 1, "test1"));
            //myList.Add(new Test(-12, 123, "test2"));
            //myList.Add(new Test(10, -12, "t"));

            //var result = myList.Where(item => item.Name.Length >= 4).Select(item => item.X).ToList();
            //var result2 = myList.Where(item => item.Name == "t").ToList();
            //var testFind = myList.Where(item => item.Name == "Bob").First();
            ;
        }
    }
}
