using System;
using System.Collections.Generic;
using System.Text;

namespace Weighted_Directed_Graph
{
    public class Graph<T>
    {
        private List<Vertex<T>> verticies = new List<Vertex<T>>();
        public IReadOnlyList<Vertex<T>> Verticies => verticies;
        public IReadOnlyList<Edge<T>> Edges
        {
            get
            {
                List<Edge<T>> list = new List<Edge<T>>();
                for (int i = 0; i < verticies.Count; i++)
                {
                    for (int j = 0; j < verticies[i].Neighbors.Count; j++)
                    {
                        if (verticies[i].Neighbors[j].StartingPoint == verticies[i])
                        {
                            list.Add(verticies[i].Neighbors[j]);
                        }
                    }
                }
                return list;
            }
        }

        public Graph()
        {

        }

        public bool AddVertex(Vertex<T> vertex)
        {
            if (vertex != null && vertex.Neighbors == null && !verticies.Contains(vertex))
            {
                verticies.Add(vertex);
            }
            return true;
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (verticies.Contains(vertex))
            {
                for (int i = vertex.Neighbors.Count - 1; i >= 0; i--)
                {
                    if(vertex.Neighbors[i].EndingPoint == vertex)
                    {
                         
                    }
                }
            }
            else { return false; }
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

        public Edge<T> GetEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        {

        }
    }


}
