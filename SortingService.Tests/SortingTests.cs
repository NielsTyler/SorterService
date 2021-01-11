using SortingService.API.Interfaces;
using SortingService.API.Logic;
using System;
using Xunit;

namespace SortingService.Tests
{
    public class SortingTests
    {
        [Fact]
        public void BubleSortingTest()
        {
            ISortingService sorter = new BubleSorter();
            int[] simpleArray = new int[] { 5, 2, 8, 10, 1 };
            //int[] sourceSimpleArray = simpleArray;

            int[] expectedSimpleArray = new int[] { 1, 2, 5, 8, 10 };

            sorter.Sort(simpleArray);

            Assert.Equal(simpleArray, expectedSimpleArray);
        }
    }
}
