using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Weighted_Directed_Graph;

namespace AirportTest
{
    public static class TestGraph
    {
        class AirportEdges
        {
            public string Start { get; set; }
            public string End { get; set; }
            public double Distance { get; set; }
            public AirportEdges()
            {

            }

        }

        public static Graph<string> Airport = new Graph<string>();
        static TestGraph()
        {

            string vertices = File.ReadAllText("AirportProblemVerticies.txt");

            List<string> verticieslist = JsonSerializer.Deserialize<List<string>>(vertices);

            Graph<string> graph2 = new Graph<string>();

            for (int i = 0; i < verticieslist.Count; i++)
            {
                graph2.AddVertex(verticieslist[i]);
            }



            string edges = File.ReadAllText("AirportProblemEdges.txt");

            List<AirportEdges> edgeslist = JsonSerializer.Deserialize<List<AirportEdges>>(edges);

            for (int i = 0; i < edgeslist.Count; i++)
            {
                graph2.AddEdge(edgeslist[i].Start, edgeslist[i].End, edgeslist[i].Distance);
            }

            List<Vertex<string>> path = Dijkstra<string>.Dijkstra2("LAX", "SEA", graph2);
        }
    }
}
