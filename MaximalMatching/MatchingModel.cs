namespace MaximalMatching
{
    using System;
    using System.Collections.Generic;

    public class MatchingModel
    {
        public MatchingModel()
        {
            this.Matching = new List<Tuple<int, int>>();
            this.FreeVertexes = new List<int>();
        }

        public List<Tuple<int, int>> Matching { get; set; } 

        public List<int> FreeVertexes { get; set; } 

        public int[][] Graph { get; set; }

        public bool IsMatchComplete { get; set; }
    }
}