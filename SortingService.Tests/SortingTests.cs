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
    }
}
