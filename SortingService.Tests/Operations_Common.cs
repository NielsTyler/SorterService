using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SortingService.Tests
{
    public class Operations_Common
    {
        public const Double PositiveInfinity = Double.PositiveInfinity;
        [Fact]
        public void Add()
        {
            Double maxFloat = 0.0;// Double.MaxValue;

            Assert.Equal(maxFloat/0, PositiveInfinity);      
        }
    }
}
