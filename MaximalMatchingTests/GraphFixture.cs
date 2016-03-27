using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalMatchingTests
{
    using System.IO;

    using Newtonsoft.Json;

    public class GraphFixture
    {
        private List<Tuple<int, int>> tuples;

        public GraphFixture()
        {
            tuples = new List<Tuple<int, int>>();
        } 

        public int[,] GetGraphFromFile(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                return JsonConvert.DeserializeObject<int[,]>(streamReader.ReadToEnd());
            }
        }

        public void AddEdge(int firstVertex, int secondVertex)
        {
            var tuple = new Tuple<int,int>(firstVertex,secondVertex);
            tuples.Add(tuple);
        }

        public Tuple<int, int>[] GetEdges()
        {
            return tuples.ToArray();
        } 

        public int[,] CreateGraph(int n, int m,params Tuple<int,int>[] vertex)
        {
            var graph = new int[n, m];
            foreach (var tuple in vertex)
            {
                graph[tuple.Item1, tuple.Item2] = 1;
                graph[tuple.Item2, tuple.Item1] = 1;
            }
            return graph;
        }


    }
}
