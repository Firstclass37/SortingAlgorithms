using System.Diagnostics;
using SortingAlgorithms.Interfaces;
using SortingAlgorithms.Model;

namespace SortingAlgorithms.Implementations
{
    class QuickSort : ISorting
    {
        public string Name => "Quick sort (Быстрая сортировка)";

        public SortResult Sort(int[] array)
        {
            var time = Stopwatch.StartNew();
            QuickSorting(array, 0, array.Length - 1);
            return new SortResult
            {
                Time = time.Elapsed.TotalMilliseconds,
                Sorted = array
            };
        }

        private void QuickSorting(int[] array, int start, int end)
        {
            if (start < end)
            {
                var p = Partition(array, start, end);
                QuickSorting(array, start, p - 1);
                QuickSorting(array, p + 1, end);
            }
        }

        private int Partition(int[] array, int start, int end)
        {
            var pivot = end;
            var wall = start - 1;
            for (int i = start; i < pivot; i++)
            {
                if (array[i] < array[pivot])
                {
                    wall++;
                    Swap(array, wall, i);
                }
            }
            Swap(array, wall + 1, pivot);
            return wall + 1;
        }

        private void Swap(int[] array, int source, int target)
        {
            var temp = array[source];
            array[source] = array[target];
            array[target] = temp;
        }
    }
}
