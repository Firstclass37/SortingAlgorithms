using System;
using System.Diagnostics;
using SortingAlgorithms.Interfaces;
using SortingAlgorithms.Model;

namespace SortingAlgorithms.Implementations
{
    class HeapSort : ISorting
    {
        public string Name => "Heap sort (Пирамидальная сортировка)";

        public SortResult Sort(int[] array)
        {
            var watch = Stopwatch.StartNew();
            var sorted = Sorting(array);
            return new SortResult
            {
                Sorted = sorted,
                Time = watch.Elapsed.TotalMilliseconds
            };
        }

        private int[] Sorting(int[] array)
        {
            ConvertToHeap(array);
            var lastIndex = array.Length - 1;
            while (lastIndex >= 0)
            {
                Swap(array, 0, lastIndex);
                lastIndex--;
                Balancing(array, 0, lastIndex);
            }
            return array;
        }

        private void ConvertToHeap(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Balancing(array, i, array.Length - 1);
            }
        }

        private void Balancing(int[] array, int i, int end)
        {
            var currentIndex = i;
            while (true)
            {
                var leftChild = 2 * currentIndex + 1;
                var rightChild = 2 * currentIndex + 2;
                var largest = currentIndex;

                if (leftChild <= end && array[leftChild] > array[largest])
                    largest = leftChild;
                if (rightChild <= end && array[rightChild] > array[largest])
                    largest = rightChild;
                if (largest == currentIndex)
                    return;

                Swap(array, largest, currentIndex);
                currentIndex = largest;
            }
        }

        private void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
