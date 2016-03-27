namespace MaximalMatchingTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using MaximalMatching;

    using Xunit;

    public class InitialMatchingTests : IClassFixture<GraphFixture>
    {
        private readonly GraphFixture fixture;

        public InitialMatchingTests(GraphFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void TestGraphWithCompleteInitialMatching()
        {
            var graph = fixture.GetGraphFromFile("Graphs/SimpleGraph.json");
            var initialMatchin = new InitialMatching(graph);

            var result = initialMatchin.FindInitialMatching();

            result.FreeVertexes.Should().BeEmpty();
        }

        [Fact]  
        public void Test()
        {
            var graph = CreateGraph();
            var countMatch = CountMatching(graph);

            var graphWithMaximalMatch = new GraphMaximalMatching().FindMaximalMatchingInGraph(graph);


            CountMatching(graphWithMaximalMatch).Should().BeGreaterThan(countMatch);
        }

        private int[,] CreateGraph()
        {
            fixture.AddEdge(0,5);
            fixture.AddEdge(0,6);
            fixture.AddEdge(1,7);
            fixture.AddEdge(1,9);
            fixture.AddEdge(2,6);
            fixture.AddEdge(2,7);
            fixture.AddEdge(3,5);
            fixture.AddEdge(4,6);
            fixture.AddEdge(4,8);

            var edges = fixture.GetEdges();
            return fixture.CreateGraph(10, 10, edges);
        }

        private int CountMatching(int[,] graph)
        {
            var count = 0;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (graph[i, j] == 2)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

    }
}
