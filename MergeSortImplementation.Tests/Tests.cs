using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace MergeSortImplementation.Tests
{
    public class Tests
    {
        [TestCase(new int[]{1,4,6,2}, Program.SortOrder.asc, new int[]{1,2,4,6})]
        [TestCase(new int[]{1,2,15,22}, Program.SortOrder.asc, new int[]{1,2,15,22})]
        [TestCase(new int[]{1,4,6,24}, Program.SortOrder.desc, new int[]{24,6,4,1})]
        [TestCase(new int[]{133,24,6,2}, Program.SortOrder.asc, new int[]{2,6,24,133})]
        [TestCase(new int[]{41,41,6,2}, Program.SortOrder.desc, new int[]{41,41,6,2})]
        public void MergeSort_ReturnsCorrectSortedArray(int[] input, Program.SortOrder sortOrder, int[] output)
        {
            Assert.AreEqual(Program.MergeSort(input, sortOrder), output);
        }
    }
}