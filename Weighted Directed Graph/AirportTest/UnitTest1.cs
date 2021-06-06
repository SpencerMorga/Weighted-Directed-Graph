using System;
using Xunit;
using Weighted_Directed_Graph;
using System.Collections.Generic;

namespace AirportTest
{
    public class AirportTests
    {
        //[Theory]
        //[InlineData(5, new int[] { 2, 3, 4, 5 })]
        //[InlineData(2, new int[] { 2, 3, 4, 5 })]
        //[InlineData(5, new int[] {})]
        //public void Test1(int x, int[] arr)
        //{
        //    Assert.Equal(5, x);
        //    Assert.NotEmpty(arr);
        //} 

        [Theory]
        [InlineData("STL", "LAX", new string[]{"STL","DTW","MKC","DFW","PHX","LAX"})]

        /*
         * STL,DTW,MKC,DFW,PHX,LAX
           PDX,SFO,PHX,LAX,JFK,PHL,DCA
           CVG,JFK,SAT,ELP,PHX,LAS,DEN,STL,DTW
           PHL,DCA,JFK,SAT,ELP,PHX,LAS,DEN,STL,MDW,IND
           MDW,MKC,ABQ,LAS,SEA,SMF
         */
        public void AirportProblemTest(string start, string end, string[] correctpath)
        {
            List<Vertex<string>> path = Dijkstra<string>.Dijkstra2(start, end, TestGraph.Airport);
            for (int i = 0; i < correctpath.Length; i++)
            {
                Assert.Equal(correctpath[i], path[i].Value);
            }
        }
        

    }
}
