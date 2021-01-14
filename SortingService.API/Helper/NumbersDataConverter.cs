using SortingService.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SortingService.API.Helper
{
    public static class NumbersDataConverter
    {
        private static readonly char _separator = ' ';
        public static int[] Convert(string strNumbers)
        {
            if (!String.IsNullOrEmpty(strNumbers))
            {
                try
                {
                    return strNumbers.Split(_separator).Select(Int32.Parse).ToArray();

                }
                catch (OverflowException ex)
                {
                    throw new SSException(ex.Message) { Value = "Input string contains value either too large or too small for an Int32.", Status = (int)HttpStatusCode.BadRequest };
                }
                catch (Exception ex)
                {
                    throw new SSException(ex.Message) { Value = "Input string contains non-integers or wrong format data.", Status = (int)HttpStatusCode.BadRequest };
                }
            }
    
            throw new SSException() { Value = "Required parameter is empty.", Status = (int)HttpStatusCode.BadRequest };
        }

        public static string Convert(int[] numbers)
        {
            return string.Join(_separator, numbers);
        }        
    }    
}
