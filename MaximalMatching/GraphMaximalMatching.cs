namespace MaximalMatching
{
    public class GraphMaximalMatching
    {
        public int[,] FindMaximalMatchingInGraph(int[,] graph)
        {
            var initialMatchin = new InitialMatching(graph);
            var result = initialMatchin.FindInitialMatching();
            var elementAdjust = new CreateDirectGraph(result.Graph);
            var directedGraph = elementAdjust.AdjustGraphVertexDirection();
            var extensionPath = new ExtensionPath();
            var path = extensionPath.GetLongestExtensionPath(directedGraph, result.FreeVertexes);
            MaximalMatchingHelpers.RemovePreviousMatching(directedGraph, path);
            MaximalMatchingHelpers.RemoveEdges(directedGraph, path);
            MaximalMatchingHelpers.AddNewMatches(directedGraph, path);
            MaximalMatchingHelpers.AddNewEdges(directedGraph, path);
            return directedGraph;
        }
    }
}
