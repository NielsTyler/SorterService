using SortingService.API.Exceptions;
using SortingService.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Logic
{
    public class BubbleSorter : ISortingService
    {
        public void Sort(int[] data)
        {
            bool swapped = true;
            int tmp;

            while (swapped)
            {
                swapped = false;

                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        tmp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = tmp;

                        swapped = true;
                    }
                }
            }
        }
    }
}
