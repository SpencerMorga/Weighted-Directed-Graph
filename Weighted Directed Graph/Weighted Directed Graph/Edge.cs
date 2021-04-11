using System;
using System.Collections.Generic;
using System.Text;

namespace Weighted_Directed_Graph
{
    public class Edge<T>
    {
        public double Distance;
        public Vertex<T> StartingPoint;
        public Vertex<T> EndingPoint;

        public Edge(double distance, Vertex<T> startingpoint, Vertex<T> endingpoint)
        {
            this.StartingPoint = startingpoint;
            this.EndingPoint = endingpoint;
            this.Distance = distance;
        }
    }
}
