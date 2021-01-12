using SortingService.API.Interfaces;
using SortingService.API.Logic;
using System;
using Xunit;

namespace SortingService.Tests
{
    public class SortingTests
    {
        [Theory]
        [InlineData(new int[] { 5, 2, 8, 10, 1 }, new int[] { 1, 2, 5, 8, 10 })]
        [InlineData(new int[] { 5 }, new int[] { 5 })]
        public void BubbleSortingTest(int[] heap, int[] expectedArray)
        {
            ISortingService sorter = new BubbleSorter();    
            sorter.Sort(heap);

            Assert.Equal(heap, expectedArray);
        }

        [Theory]
        [InlineData(new int[] { 4, 7, 2, 9, 6, 1 }, new int[] { 1, 2, 4, 6, 7, 9 })]
        [InlineData(new int[] { 5, 2, 8, 10, 1 }, new int[] { 1, 2, 5, 8, 10 })]
        [InlineData(new int[] { 100, 2, 1201, 3, 444, 343434, 232 }, new int[] { 2, 3, 100, 232, 444, 1201, 343434 })]
        [InlineData(new int[] { 7, 2, 8 }, new int[] { 2, 7, 8 })]
        [InlineData(new int[] {7, 2 }, new int[] { 2, 7 })]
        [InlineData(new int[] { 5 }, new int[] { 5 })]
        public void QuickSortingTest(int[] heap, int[] expectedArray)
        {
            ISortingService sorter = new QuickSorter();
            sorter.Sort(heap);

            Assert.Equal(heap, expectedArray);
        }
    }
}
