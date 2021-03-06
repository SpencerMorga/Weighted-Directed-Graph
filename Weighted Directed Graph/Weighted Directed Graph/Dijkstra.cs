using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Weighted_Directed_Graph
{
    public static class Dijkstra<T>
    {
        public static List<Vertex<T>> Dijkstra2(T startingPoint, T endingPoint, Graph<T> graph) 
        {
            List<Vertex<T>> path = new List<Vertex<T>>();
            Comparer<(Vertex<T>, double)> comparer = Comparer<(Vertex<T>, double)>.Create((x, y) => x.Item2.CompareTo(y.Item2));
            PriorityQueue<(Vertex<T>, double)> pque = new PriorityQueue<(Vertex<T> current, double distance)>(comparer);

            Dictionary<Vertex<T>, (Vertex<T>, double)> dictionary = new Dictionary<Vertex<T>, (Vertex<T> parent, double distance)>();

            Vertex<T> vertexA = graph.Search(startingPoint);
            Vertex<T> vertexB = graph.Search(endingPoint);
            if (vertexA == null || vertexB == null)
            {
                return null;
            }

            for (int i = 0; i < graph.Verticies.Count; i++)
            {
                graph.Verticies[i].isVisited = false;
                dictionary.Add(graph.Verticies[i], (null, double.PositiveInfinity));
            }

            dictionary[vertexA] = (null, 0);
            pque.Enqueue((vertexA, 0));
            (Vertex<T> current, double dist) current;
            while (pque.Count != 0)
            {
                current = pque.Dequeue();
                if (current.current.isVisited == true)
                {
                    continue;
                }
                for (int i = 0; i < current.current.Neighbors.Count; i++)
                {
                    double tentativeDistance = current.current.Neighbors[i].Distance + current.dist;

                    (Vertex<T> current, double dist) neighbor = dictionary[current.current.Neighbors[i].EndingPoint];

                    if (neighbor.dist.CompareTo(tentativeDistance) == 1)
                    {
                        neighbor.dist  = tentativeDistance;

                        dictionary[current.current.Neighbors[i].EndingPoint] = (current.current, neighbor.dist);
                        
                    }

                    if (current.current.Neighbors[i].EndingPoint.isVisited == false && !pque.Contains((current.current.Neighbors[i].EndingPoint, current.current.Neighbors[i].Distance)))
                    {
                        pque.Enqueue((current.current.Neighbors[i].EndingPoint, current.current.Neighbors[i].Distance));
                    }

                    current.current.isVisited = true;

                    if (current.current == vertexB)
                    {
                        path.Add(vertexB);
                        while (current.current != vertexA)
                        {
                            Vertex<T> parent = dictionary[current.current].Item1;
                            path.Add(parent);
                            current.current = parent;
                        }
                        
                        path.Reverse();
                    }
                }
            }
            if (path.Count == 0)
            {
                throw new Exception("No Path Was FOund.");
            }
            return path;

        }
    }
}
