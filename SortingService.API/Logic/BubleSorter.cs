using SortingService.API.Exceptions;
using SortingService.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Logic
{
    public class BubleSorter : ISortingService
    {
        public void Sort(int[] data)
        {
            Array.Sort(data);     
        }        
    }
}
