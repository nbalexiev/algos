using NUnit.Framework;
using System;

namespace Algos.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class MaximumMinimumPathTests
    {
        private static readonly object[] _cases =
        {
            new Tuple<int[][], int> (new int[][] { 
                    new int[] { 5, 4, 5 }, 
                    new int[] { 1, 2, 6 }, 
                    new int[] { 7, 4, 6 } 
                },  4),
            new Tuple<int[][], int> (new int[][] {
                    new int[] { 1, 1, 0, 3, 1, 1 }, 
                    new int[] { 0, 1, 0, 1, 1, 0 }, 
                    new int[] { 3, 3, 1, 3, 1, 1 },
                    new int[] { 0, 3, 2, 2, 0, 0 },
                    new int[] { 1, 0, 1, 2, 3, 0 }
                }, 0),
        };

        [Test, TestCaseSource(nameof(_cases))]
        public void MaximumMinimumPath_DFS(Tuple<int[][], int> input)
        {
            var s = new MaximumMinimumPathSolution();
            Assert.That(s.MaximumMinimumPath_DFS(input.Item1), Is.EqualTo(input.Item2));
        }

        [Test, TestCaseSource(nameof(_cases))]
        public void MaximumMinimumPath_Dijkstra(Tuple<int[][], int> input)
        {
            var s = new MaximumMinimumPathSolution();
            Assert.That(s.MaximumMinimumPath_Dijkstra(input.Item1), Is.EqualTo(input.Item2));
        }
    }
}