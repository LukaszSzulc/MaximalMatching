using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalMatching
{
    public class ExtensionPath
    {
        private List<List<Tuple<int, int>>> paths;

        private Bfs bfs;

        public ExtensionPath()
        {
            paths = new List<List<Tuple<int, int>>>();
            bfs = new Bfs();
        }

        public List<Tuple<int, int>> GetLongestExtensionPath(int[,] graph, List<int> freeVertexes)
        {
            foreach (var startVertex in freeVertexes)
            {
                var path = bfs.FindPath(startVertex, graph).ToList();
                if (IsExtensionPath(path, freeVertexes, startVertex))
                {
                    paths.Add(path);
                }
            }

            return paths.OrderByDescending(x=>x.Count).First().ToList();
        }


        private bool IsExtensionPath(List<Tuple<int,int>> path, List<int> freeVertexes, int startVertex)
        {
            var lastElement = path.Last().Item2;
            if (startVertex == lastElement)
            {
                return false;
            }

            var count = freeVertexes.Count(x => x == lastElement);
            return count != 0;
        }
    }
}
