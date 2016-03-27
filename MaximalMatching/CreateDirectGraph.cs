namespace MaximalMatching
{
    public class CreateDirectGraph
    {
        private readonly int[,] graph;

        public CreateDirectGraph(int[,] graph)
        {
            this.graph = graph;
        }

        public int[,] AdjustGraphVertexDirection()
        {
            AdjustElementsDirection();
            return graph;
        }

        private void AdjustElementsDirection()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (graph[i, j] == 2)
                    {
                        graph[j, i] = 0;
                    }
                    else
                    {
                        graph[i, j] = 0;
                    }
                }
            }
        }

    }
}
