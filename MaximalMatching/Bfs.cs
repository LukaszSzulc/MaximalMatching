namespace MaximalMatching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bfs
    {
        private readonly int[,] graph;

        private Queue<int> neighbors;

        private Queue<Tuple<int,int>> path; 

        public Bfs(int[,] graph)
        {
            this.graph = graph;
            neighbors = new Queue<int>();
            path = new Queue<Tuple<int,int>>();
        }

        public Queue<Tuple<int,int>> FindPath(int startVertex)
        {
            neighbors.Enqueue(startVertex);
            do
            {
                var vertex = neighbors.Dequeue();
                for (var i = 0; i < graph.GetLength(1); i++)
                {
                    if (graph[vertex, i] == 1 || graph[vertex,i] == 2)
                    {
                        var count = path.Count(x => x.Item1 == i || x.Item2 == i);
                        if (count == 0)
                        {
                            neighbors.Enqueue(i);

                        }
                    }
                }

                if (neighbors.Any())
                {
                    path.Enqueue(new Tuple<int, int>(vertex, neighbors.Peek()));

                }

            }
            while (neighbors.Any());
            return path;
        }
    }
}
