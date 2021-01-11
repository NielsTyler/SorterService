using SortingService.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Helper
{
    public class NumbersDataConverter
    {
        public static int[] ValidateAndConvert(string strNumbers)
        {
            if (!String.IsNullOrEmpty(strNumbers))
            {
                try
                {
                    return strNumbers.Split(' ').Select(Int32.Parse).ToArray();

                }
                catch (Exception)
                {
                    throw new SSException("Validation error. Parameter can not contain not integer items.");
                }
            }
    
            throw new SSException("Required parameter is empty.");
        }

        public static string Convert(int[] numbers, char separator = ' ')
        {
            return string.Join(separator, numbers);
        }
    }    
}
