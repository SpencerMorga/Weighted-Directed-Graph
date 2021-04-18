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

            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.RemoveVertex(6);

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
