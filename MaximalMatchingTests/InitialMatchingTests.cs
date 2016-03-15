namespace MaximalMatchingTests
{
    using System;
    using System.Collections.Generic;

    using FluentAssertions;

    using MaximalMatching;

    using Xunit;

    public class InitialMatchingTests
    {
        [Fact]
        public void TestGraphWithCompleteInitialMatching()
        {
            var graph = CreateSampleGraphWithCompleteMatching();
            var initialMatchin = new InitialMatching(graph);

            var result = initialMatchin.FindInitialMatching();

            result.FreeVertexes.Should().BeEmpty();
            result.Matching.Should().BeEquivalentTo(CreateResultForGraphWithFullMatching());
        }

        [Fact]
        public void TestGraphWithoutInitialMaching()
        {
            var graph = CreateGraphWithoutCompleteMatching();
            var initialMatchin = new InitialMatching(graph);

            var result = initialMatchin.FindInitialMatching();

            result.FreeVertexes.Should().BeEquivalentTo(new List<int> { 2, 3 });
            result.Matching.Should().BeEquivalentTo(CreateResultForGraphWithoutFullMatching());
        }

        [Fact]
        public void WhenInitialMatchinFindCompletedGraphItShouldSetFlagToTrue()
        {
            var graph = CreateSampleGraphWithCompleteMatching();

            var initialMatchin = new InitialMatching(graph).FindInitialMatching();

            initialMatchin.IsMatchComplete.Should().BeTrue();
        }

        [Fact]
        public void WhenInitialMatchinDoesNotFindCompletedGraphItShouldSetFlagToFalse()
        {
            var graph = CreateGraphWithoutCompleteMatching();

            var initialMatchin = new InitialMatching(graph).FindInitialMatching();

            initialMatchin.IsMatchComplete.Should().BeFalse();
        }

        [Fact]
        public void TestComplexGraphWithoutInitialMatching()
        {
            var graph = CreateComplexGraph();

            var initial = new InitialMatching(graph).FindInitialMatching();

            initial.FreeVertexes.Should().BeEquivalentTo(new List<int> { 3, 4 });
            initial.Matching.Should().BeEquivalentTo(CreateResultForComplexGraphWithoutFullMatching());
        }
        
        private int[][] CreateSampleGraphWithCompleteMatching()
        {
            var graph = new int[6][];
            graph[0] = new[] { 0, 0, 0, 1, 1, 0 };
            graph[1] = new[] { 0, 0, 0, 0, 1, 1 };
            graph[2] = new[] { 0, 0, 0, 0, 1, 1 };
            graph[3] = new[] { 1, 0, 0, 0, 0, 0 };
            graph[4] = new[] { 1, 1, 0, 0, 0, 0 };
            graph[5] = new[] { 0, 1, 1, 0, 0, 0 };
            return graph;

        }

        private int[][] CreateGraphWithoutCompleteMatching()
        {
            var graph = new int[6][];
            graph[0] = new[] { 0, 0, 0, 0, 1, 1 };
            graph[1] = new[] { 0, 0, 0, 0, 1, 1 };
            graph[2] = new[] { 0, 0, 0, 0, 1, 0 };
            graph[3] = new[] { 0, 0, 0, 0, 0, 1 };
            graph[4] = new[] { 1, 1, 1, 0, 0, 0 };
            graph[5] = new[] { 1, 1, 0, 1, 0, 0 };
            return graph;
        }

        private int[][] CreateComplexGraph()
        {
            var graph = new int[8][];
            graph[0] = new []{ 0, 0, 0, 0, 0, 1, 1, 1 };
            graph[1] = new[] { 0, 0, 0, 0, 0, 1, 0, 1 };
            graph[2] = new[] { 0, 0, 0, 0, 0, 0, 1, 0 };
            graph[3] = new[] { 0, 0, 0, 0, 0, 1, 0, 0 };
            graph[4] = new[] { 0, 0, 0, 0, 0, 0, 1, 1 };
            graph[5] = new[] { 0, 1, 0, 1, 0, 0, 0, 0 };
            graph[6] = new[] { 1, 0, 0, 1, 0, 0, 0, 0 };
            graph[7] = new[] { 1, 1, 0, 0, 1, 0, 0, 0 };

            return graph;

        }

        private List<Tuple<int, int>> CreateResultForGraphWithFullMatching()
        {
            return new List<Tuple<int, int>>
                       {
                           new Tuple<int, int>(0, 3),
                           new Tuple<int, int>(1, 4),
                           new Tuple<int, int>(2, 5)
                       };
        }

        private List<Tuple<int, int>> CreateResultForGraphWithoutFullMatching()
        {
            return new List<Tuple<int, int>>
                       {
                           new Tuple<int, int>(0, 4),
                           new Tuple<int, int>(1, 5)
                       };
        }

        private List<Tuple<int, int>> CreateResultForComplexGraphWithoutFullMatching()
        {
            return new List<Tuple<int, int>>
                       {
                           new Tuple<int, int>(0, 5),
                           new Tuple<int, int>(1, 7),
                           new Tuple<int, int>(2, 6)
                       };
        }

    }
}
