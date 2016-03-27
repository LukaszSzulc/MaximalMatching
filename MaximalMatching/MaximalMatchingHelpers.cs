using System;
using System.Collections.Generic;

namespace MaximalMatching
{
    public static class MaximalMatchingHelpers
    {

        public static void RemovePreviousMatching(int[,] graph, List<Tuple<int, int>> vertexes)
        {
            for (int i = 1; i < vertexes.Count; i += 2)
            {
                var vertex = vertexes[i];
                if (vertex.Item2 > vertex.Item1)
                {
                    graph[vertex.Item2, vertex.Item1] = 0;
                }
                else
                {
                    graph[vertex.Item1, vertex.Item2] = 0;
                }
            }
        }

        public static void RemoveEdges(int[,] graph, List<Tuple<int, int>> vertexes)
        {
            for (int i = 0; i < vertexes.Count; i += 2)
            {
                var vertex = vertexes[i];
                if (vertex.Item2 > vertex.Item1)
                {
                    graph[vertex.Item1, vertex.Item2] = 0;
                }
                else
                {
                    graph[vertex.Item2, vertex.Item1] = 0;

                }
            }
        }

        public static void AddNewMatches(int[,] graph, List<Tuple<int, int>> vertexes)
        {
            for (int i = 0; i < vertexes.Count; i += 2)
            {
                var vertex = vertexes[i];
                if (vertex.Item2 > vertex.Item1)
                {
                    graph[vertex.Item2, vertex.Item1] = 2;
                }
                else
                {
                    graph[vertex.Item1, vertex.Item2] = 2;

                }
            }
        }

        public static void AddNewEdges(int[,] graph, List<Tuple<int, int>> vertexes)
        {
            for (int i = 1; i < vertexes.Count; i += 2)
            {
                var vertex = vertexes[i];
                if (vertex.Item2 > vertex.Item1)
                {
                    graph[vertex.Item1, vertex.Item2] = 1;
                }
                else
                {
                    graph[vertex.Item2, vertex.Item1] = 1;

                }
            }
        }
    }
}
