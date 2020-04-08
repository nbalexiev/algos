using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    public class MaximumMinimumPathSolution
    {
        private static readonly int[][] neighbours = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };

        private readonly PriorityQueue<int, Tuple<int, int>> q = new PriorityQueue<int, Tuple<int, int>>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        private int R;
        private int C;

        public int MaximumMinimumPath(int[][] A)
        {
            //return MaximumMinimumPath_Dijkstra(A);
            return MaximumMinimumPath_DFS(A);
        }

        public int MaximumMinimumPath_DFS(int[][] A)
        {
            R = A.Length;
            C = A[0].Length;

            bool[,] visited = new bool[R, C];

            int score = A[0][0];
            q.Enqueue(A[0][0], new Tuple<int, int>(0, 0));

            while (!q.IsEmpty())
            {
                var start = q.Dequeue();
                score = Math.Min(score, start.Key);
                if (Dfs(start.Value.Item1, start.Value.Item2, A, score, visited)) break;
            }

            return Math.Min(score, A[R-1][C-1]);
        }

        private bool Dfs(int r, int c, int[][] A, int score, bool[,] visited)
        {
            if (r == R - 1 && c == C - 1)
            {
                return true;
            }

            if (r >= 0 && r < R && c >= 0 && c < C)
            {
                if (visited[r, c])
                {
                    return false;
                }

                if (A[r][c] < score)
                {
                    q.Enqueue(A[r][c], new Tuple<int, int>(r, c));
                    return false;
                }

                visited[r, c] = true;

                foreach (var neighbour in neighbours)
                {
                    int nr = r + neighbour[0];
                    int nc = c + neighbour[1];

                    if (Dfs(nr, nc, A, A[r][c], visited))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int MaximumMinimumPath_Dijkstra(int[][] A)
        {
            R = A.Length;
            C = A[0].Length;

            int maxMinValue = A[0][0];
            q.Enqueue(A[0][0], new Tuple<int, int>(0, 0));
            A[0][0] = -1;

            while (!q.IsEmpty())
            {
                var top = q.Dequeue();
                int curr = top.Key;
                int r = top.Value.Item1;
                int c = top.Value.Item2;

                maxMinValue = Math.Min(maxMinValue, curr);
                if (r == R - 1 && c == C - 1)
                {
                    break;
                }

                foreach (var neighbour in neighbours)
                {
                    int nr = r + neighbour[0];
                    int nc = c + neighbour[1];

                    if (nr >= 0 && nr < R && nc >= 0 && nc < C && A[nr][nc] != -1)
                    {
                        q.Enqueue(A[nr][nc], new Tuple<int, int>(nr, nc));
                        A[nr][nc] = -1;
                    }
                }
            }

            return maxMinValue;
        }
    }
}
