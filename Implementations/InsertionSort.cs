using System.Diagnostics;
using SortingAlgorithms.Interfaces;
using SortingAlgorithms.Model;

namespace SortingAlgorithms.Implementations
{
    public class InsertionSort : ISorting
    {
        public string Name => "Insertion Sort (Сортировка вставками)";

        public SortResult Sort(int[] array)
        {
            var stopWatch = Stopwatch.StartNew();
            SortArray(array);
            return new SortResult
            {
                Sorted = array,
                Time = stopWatch.Elapsed.TotalMilliseconds,
            };
        }

        private void SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Move(array, i);
            }
        }

        private void Move(int[] array, int index)
        {
            var i = index;
            while(i > 0 && array[i] < array[i-1])
            {
                Swap(array, i, i-1);
                i--;
            }
        }

        private void Swap(int[] array, int source, int target)
        {
            var temp = array[source];
            array[source] = array[target];
            array[target] = temp;
        }
    }
}