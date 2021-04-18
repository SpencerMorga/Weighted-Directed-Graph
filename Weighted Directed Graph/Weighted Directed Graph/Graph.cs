using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public void AddVertex(T value)
        {
            Vertex<T> a = new Vertex<T>(value);
            AddVertex(a);
        }
        public bool AddVertex(Vertex<T> vertex)
        {
            var result = verticies.Where(item => item.Value.Equals(vertex.Value)).ToList();
            if (vertex != null && vertex.Neighbors == null)
            {
                if (result.Count == 0)
                {
                    verticies.Add(vertex);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveVertex(T value)
        {
            Vertex<T> a = Search(value);
            if (a == null)
            {
                return false;
            }
            RemoveVertex(a);
            return true;
        }
        private void RemoveVertex(Vertex<T> vertex)
        {
            if (verticies.Contains(vertex))
            {
                if (vertex.Neighbors != null)
                {
                    for (int i = vertex.Neighbors.Count - 1; i >= 0; i--)
                    {
                        if (vertex.Neighbors[i].EndingPoint == vertex)
                        {
                            RemoveEdge(vertex.Neighbors[i].StartingPoint, vertex);
                        }
                    }
                }
                verticies.Remove(vertex);
            }
        }

        //public bool AddEdge(Vertex<T> vertexA, Vertex<T> vertexB, double distance)
        //{

        //}

        public bool RemoveEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        {
            if (verticies.Contains(vertexA) && verticies.Contains(vertexB))
            {
                for (int i = 0; i < vertexA.Neighbors.Count; i++)
                {
                    if (vertexA.Neighbors[i].EndingPoint == vertexB)
                    {
                        vertexA.Neighbors.Remove(vertexA.Neighbors[i]);
                        return true;
                    }
                }
            }
            return false;
        }

        public Vertex<T> Search(T value)
        {
            var result = verticies.Where(item => item.Value.Equals(value)).ToList();
            if (result.Count != 0)
            {
                return result.First();
            }
            return null;

           /* for (int i = 0; i < verticies.Count; i++)
            {
                if (verticies[i].Value.Equals(value))
                {
                    return verticies[i];
                }
            }
            return null;*/
        }

        //public Edge<T> GetEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        //{

        //}
    }


}
