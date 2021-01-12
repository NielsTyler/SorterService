using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Exceptions
{
    public class SSException: Exception
    {
        public SSException()
        {
        }

        public SSException(string message)
            : base(message)
        {
        }

        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}
