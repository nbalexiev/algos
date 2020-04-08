using NUnit.Framework;
using System;

namespace Algos.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SortTests
    {
        [TestCase(new int[]{ 7, 1 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1 })]
        [TestCase(new int[] { 7, 8, 1, 6, 3 })]
        public void MergeSortTests(int[] arr)
        {
            var sortedArr = (int[])arr.Clone();
            Array.Sort(sortedArr);
            Sort<int>.MergeSort(arr);
            Assert.That(arr, Is.EqualTo(sortedArr));
        }

        [TestCase(new int[] { 7, 1 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1 })]
        [TestCase(new int[] { 7, 8, 1, 6, 3 })]
        public void QuickSortTests(int[] arr)
        {
            var sortedArr = (int[])arr.Clone();
            Array.Sort(sortedArr);
            Sort<int>.QuickSort(arr);
            Assert.That(arr, Is.EqualTo(sortedArr));
        }
    }
}
