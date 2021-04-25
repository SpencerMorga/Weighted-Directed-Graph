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
            if (vertex != null && vertex.Neighbors.Count == 0)
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
                        else
                        {
                            RemoveEdge(vertex, vertex.Neighbors[i].EndingPoint);
                        }
                    }
                }
                verticies.Remove(vertex);
            }
        }

        public void AddEdge(T valueA, T valueB, double distance)
        {
            Vertex<T> vertexA = Search(valueA);
            Vertex<T> vertexB = Search(valueB);
            AddEdge(vertexA, vertexB, distance);
        }
        private bool AddEdge(Vertex<T> vertexA, Vertex<T> vertexB, double distance)
        {
            if (verticies.Contains(vertexA) && verticies.Contains(vertexB) && vertexA != null && vertexB != null)
            {
                var result = vertexA.Neighbors.Where(item => item.EndingPoint == vertexB).ToList();
                if (result.Count == 0)
                {
                    Edge<T> newedge = new Edge<T>(distance, vertexA, vertexB);
                    vertexA.Neighbors.Add(newedge);
                    vertexB.Neighbors.Add(newedge);
                    return true;

                }
                    //var testFind = myList.Where(item => item.Name == "Bob").First();
            }
            return false;
        }

        public bool RemoveEdge(T valueA, T valueB)
        {
            Vertex<T> vertexA = Search(valueA);
            Vertex<T> vertexB = Search(valueB);
            if (vertexA != null && vertexB != null)
            {
                RemoveEdge(vertexA, vertexB);
                return true;
            }
            return false;
        }
        private bool RemoveEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        {
            if (verticies.Contains(vertexA) && verticies.Contains(vertexB))
            {
                for (int i = 0; i < vertexA.Neighbors.Count; i++)
                {
                    if (vertexA.Neighbors[i].EndingPoint == vertexB)
                    {
                        vertexB.Neighbors.Remove(vertexA.Neighbors[i]);
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
        public Edge<T> GetEdge(T valueA, T valueB)
        {
            Vertex<T> vertexA = Search(valueA);
            Vertex<T> vertexB = Search(valueB);
            return GetEdge(vertexA, vertexB);
        }
        private Edge<T> GetEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        {
            if (vertexA != null && vertexB != null)
            {
                for (int i = 0; i < vertexA.Neighbors.Count; i++)
                {
                    if (vertexA.Neighbors[i].EndingPoint == vertexB)
                    {
                        return vertexA.Neighbors[i];
                    }
                }
            }
            return null;
        }

        public List<Vertex<T>> BreadthFirstSearch(T valueA, T valueB)
        {
            Dictionary<Vertex<T>, Vertex<T>> dictionary = new Dictionary<Vertex<T>, Vertex<T>>();
            List<Vertex<T>> path = new List<Vertex<T>>();
            for (int i = 0; i < verticies.Count; i++)
            {
                verticies[i].isVisited = false;
            }
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            Vertex<T> vertexA = Search(valueA);
            Vertex<T> vertexB = Search(valueB);

            Vertex<T> current = vertexA;
            queue.Enqueue(current);
            while (queue.Count != 0)
            {
                current = queue.Dequeue();
     
                if (current.Equals(valueB))
                {

                }
                for (int i = 0; i < current.Neighbors.Count; i++)
                {
                    if (current.Neighbors[i].EndingPoint != current && current.Neighbors[i].EndingPoint.isVisited == false)
                    {
                        queue.Enqueue(current.Neighbors[i].EndingPoint);
                        dictionary.Add(current.Neighbors[i].EndingPoint, current);
                        current.Neighbors[i].EndingPoint.isVisited = true;

                    }
                }

                
            }
        }
    }


}
