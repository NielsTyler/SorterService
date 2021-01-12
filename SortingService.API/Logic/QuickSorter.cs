using SortingService.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Logic
{
    public class QuickSorter : ISortingService
    {
        private int[] _data;
        public void Sort(int[] data)
        {
            _data = data;
            PartitionReorder(0, data.Length - 1);
        }

        public void PartitionReorder(int startIndex, int endIndex)
        {
            int pivotIndex = endIndex;

            if (endIndex == startIndex)
                return;

            for (int i = startIndex; i <= pivotIndex - 1; )
            {
                if (_data[i] > _data[pivotIndex])
                {
                    //swap
                    int largerThanPivot = _data[i];                    
                    int pivot = _data[pivotIndex];                                       

                    //only more than one item before the pivot
                    if (i != pivotIndex - 1)
                    {
                        int nearestToPivot = _data[pivotIndex - 1];
                        _data[i] = nearestToPivot;
                    }

                    _data[pivotIndex - 1] = pivot;
                    _data[pivotIndex] = largerThanPivot;

                    pivotIndex -= 1;
                }
                else
                {
                    i++;
                }
            }

            Debug.WriteLine("Result reordering = " + string.Join(",", _data.Take(_data.Length)));

            //left
            if (pivotIndex != 0 && startIndex != pivotIndex)
            {                
                PartitionReorder(startIndex, pivotIndex - 1);
            }

            //right
            if (pivotIndex != _data.Length - 1)
            {               
                PartitionReorder(pivotIndex + 1, endIndex);
            }
        }
    }
}
