using System.Diagnostics;
using SortingAlgorithms.Interfaces;
using SortingAlgorithms.Model;

namespace SortingAlgorithms.Implementations
{
    public class CocktailSort : ISorting
    {
        public string Name => "Cocktail sort (Сортировка перемешиванием)";
        
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
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < array[i - 1])
                    {
                        Swap(array, i, i - 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;

                swapped = false;
                for (int i = array.Length - 1; i > 1; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        Swap(array, i, i - 1);
                        swapped = true;
                    }
                }
            } while (swapped);

        }

        private void Swap(int[] array, int source, int target)
        {
            var temp = array[source];
            array[source] = array[target];
            array[target] = temp;
        }
    }
}