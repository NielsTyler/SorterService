using SortingService.API.Exceptions;
using SortingService.API.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SortingService.Tests
{
    public class MapperTests
    {
        [Theory]
        [InlineData("1 4 5 21", new int[] { 1, 4, 5, 21})]

        public void ConvertStringToArrayTest(string source, int[] expectedResult)
        {
            int[] result = NumbersDataConverter.Convert(source);

            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData("1 4 5 b#")]
        [InlineData("1 4 5 21474836479")]
        public void WrongDataToArrayTest(string source)
        {
            Assert.Throws<SSException>(() => NumbersDataConverter.Convert(source));
        }

        [Fact]
        public void ConvertResultArrayToString()
        {
            string res = NumbersDataConverter.Convert(new int[] { 1, 2, 3, 5, 7, 110 });

            Assert.Equal(res, "1 2 3 5 7 110");
        }
    }
}
