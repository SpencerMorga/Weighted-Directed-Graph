using System;
using System.Collections.Generic;
using System.Text;

namespace Weighted_Directed_Graph
{
    public class Vertex<T>
    {
        public T Value;
        public List<Edge<T>> Neighbors;
        public bool isVisited;

        public Vertex(T value)
        {
            this.Value = value;
            Neighbors = new List<Edge<T>>();
        }
         
    }
}
