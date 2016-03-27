// ReSharper disable All
namespace MaximalMatching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InitialMatching
    {
        private int[,] _graph;

        private List<int> _freeVertexes;

        private List<Tuple<int, int>> _matching;  

        public InitialMatching(int[,] graph)
        {
            _graph = graph;
            _freeVertexes = new List<int>();
            _matching = new List<Tuple<int, int>>();
        }

        public MatchingModel FindInitialMatching()
        {
            CreateInitialFreeVertexList();

            for (var vertex = 0; vertex < _graph.GetLength(0); vertex++)
            {
                for (var neighbour = 0; neighbour < _graph.GetLength(1); neighbour++)
                {
                    if (ConnectionExists(vertex, neighbour))
                    {
                        if (AreFreeVertexs(vertex, neighbour))
                        {
                            CreateMatchBeetweenVertxes(vertex, neighbour);
                            IncrementValuesInMatrix(vertex, neighbour);
                            RemoveVertexFromFreeList(vertex, neighbour);
                            break;
                        }
                    }
                }
            }

            return new MatchingModel
                       {
                           FreeVertexes = new List<int>(_freeVertexes),
                           Matching = new List<Tuple<int, int>>(_matching),
                           Graph = _graph,
                           IsMatchComplete = IsMatchComplite()
                       };
        }

        private void IncrementValuesInMatrix(int vertex, int neighbour)
        {
            if ( vertex < _graph.GetLength(0) && neighbour < _graph.GetLength(1))
            {
                _graph[vertex, neighbour]++;
            }

            if (neighbour < _graph.GetLength(0) && vertex < _graph.GetLength(1) && neighbour != vertex)
            {
                _graph[neighbour, vertex]++;
            }
        }

        private bool ConnectionExists(int vertex, int neighbour)
        {
            return _graph[vertex,neighbour] == 1;
        }

        private void CreateMatchBeetweenVertxes(int startVertex, int endVertex)
        {
            var newMatch =  new Tuple<int, int>(startVertex, endVertex);
            _matching.Add(newMatch);
        }

        private bool AreFreeVertexs(int vertex, int neighbour)
        {
            var freeNeighbour = _freeVertexes.Count(x=>x == neighbour);
            var freeVertex = _freeVertexes.Count(x => x == vertex);

            return freeNeighbour != 0 && freeVertex != 0;
        }

        private void RemoveVertexFromFreeList(int vertex, int neighbour)
        {
            _freeVertexes.Remove(vertex);
            _freeVertexes.Remove(neighbour);
        }

        private void CreateInitialFreeVertexList()
        {
            for (var i = 0; i < _graph.GetLength(0); i++)
            {
                _freeVertexes.Add(i);
            }
        }

        private bool IsMatchComplite()
        {
            return _freeVertexes.Count == 0;
        }
    }
}
