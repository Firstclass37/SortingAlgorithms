using System.Diagnostics;
using SortingAlgorithms.Interfaces;
using SortingAlgorithms.Model;

namespace SortingAlgorithms.Implementations
{
    public class MergeSort : ISorting
    {
        public string Name => "Merge Sort (Сортировка слиянием)";

        public SortResult Sort(int[] array)
        {
            var time = Stopwatch.StartNew();
            var sorted =  MergeSortAlg(array, 0, array.Length - 1);
            return  new SortResult
            {
                Time = time.Elapsed.TotalMilliseconds,
                Sorted = sorted
            };
        }


        private int[] MergeSortAlg(int[] array, int start, int end)
        {
            if (start == end)
                return new []{ array[start] };

            var middle = (end + start) / 2;
            var sortedLeft = MergeSortAlg(array, start, middle);
            var sortedRight = MergeSortAlg(array, middle + 1, end);
            return Merge(sortedLeft, sortedRight);
        }

        private int[] Merge(int[] first, int[] second)
        {
            var resultArray = new int[first.Length + second.Length];

            var mainIndex = -1;
            var firstIndex = 0;
            var secondIndex = 0;

            while (++mainIndex < resultArray.Length)
            {
                if (firstIndex > first.Length - 1)
                {
                    for (int i = secondIndex; i < second.Length; i++)
                    {
                        resultArray[mainIndex] = second[i];
                        mainIndex++;
                    }
                    break;
                }
                if (secondIndex > second.Length - 1)
                {
                    for (int i = firstIndex; i < first.Length; i++)
                    {
                        resultArray[mainIndex] = first[firstIndex];
                        mainIndex++;
                    }
                    break;
                }

                if (first[firstIndex] < second[secondIndex])
                {
                    resultArray[mainIndex] = first[firstIndex];
                    firstIndex++;
                }
                else
                {
                    resultArray[mainIndex] = second[secondIndex];
                    secondIndex++;
                }
            }
            return resultArray;
        }
    }
}