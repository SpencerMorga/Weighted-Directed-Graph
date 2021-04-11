using System;
using System.Collections.Generic;
using System.Text;

namespace Weighted_Directed_Graph
{
    public class Graph<T>
    {
        private List<Vertex<T>> verticies;
        public IReadOnlyList<Vertex<T>> Verticies => verticies;
        public IReadOnlyList<Edge<T>> Edges
        {
            get
            {
            }
        }

        public void AddVertex(Vertex<T> vertex)
        {

        }

        public bool RemoveVertex(Vertex<T> vertex)
        {

        }

        public bool AddEdge(Vertex<T> vertexA, Vertex<T> vertexB, double distance)
        {

        }

        public bool RemoveEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        {

        }

        public Vertex<T> Search(Vertex<T> vertex)
        {

        }
    }


}
