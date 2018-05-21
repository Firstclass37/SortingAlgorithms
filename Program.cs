using System;
using System.Collections.Generic;
using System.Linq;
using SortingAlgorithms.Implementations;
using SortingAlgorithms.Interfaces;
using SortingAlgorithms.Model;

namespace SortingAlgorithms
{
    class Program
    {
        static readonly List<ISorting> _sorting = new List<ISorting>();
        static readonly Random Random = new Random();


        static void Main(string[] args)
        {
            Run();
            //Test();
        }

        static void Run()
        {
            Register();
            while (true)
            {
                Console.Write("Count: ");
                var count = int.Parse(Console.ReadLine());

                Console.Write("Repeat: ");
                var repeat = int.Parse(Console.ReadLine());

                var resultsDic = new Dictionary<string, SortResult>();
                var sourceArrays = GenerateArrays(repeat, count);
                foreach (var sorting in _sorting)
                {
                    var result = Run(sorting, sourceArrays);
                    resultsDic.Add(sorting.Name, result);
                    Console.WriteLine($"{sorting.Name} completed");
                }
                Console.WriteLine("Completed!!!");
                Console.WriteLine("Ordered by time:");
                ShowResults(resultsDic);
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowResults(Dictionary<string, SortResult> results)
        {
            var ordered = results.OrderBy(r => r.Value.Time).ToArray();
            for (int i = 0; i < ordered.Length; i++)
            {
                var curr = ordered[i];
                Console.WriteLine($"{i+1}. {curr.Key} : time: {curr.Value.Time:f2} ms");
            }
        }




        static void Test()
        {
            Console.Write("Count: ");
            var count = int.Parse(Console.ReadLine());
            var sourceArray = Generate(count);
            var sort = new HeapSort();
            ShowSource(sourceArray);
            var sortResult = sort.Sort(sourceArray);
            ShowResult(sortResult);
            Console.ReadKey();
        }



        static void ShowSource(int[] array)
        {
            Console.Write("Source : ");
            ShowArray(array);
            Console.WriteLine();
        }

        static void ShowResult(SortResult sortResult)
        {
            Console.Write("Sorted : ");
            ShowArray(sortResult.Sorted);
            Console.WriteLine();

            Console.WriteLine($"Sorted result : time: {sortResult.Time:f2} ms");
        }

        static void ShowArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element);
                Console.Write(" ");
            }
        }

        static SortResult Run(ISorting sorting, List<int[]> arrays)
        {
            var results = new List<SortResult>();
            foreach (var array in arrays)
            {
                var res = sorting.Sort(array.ToArray());
                if (!IsCorrectSorted(res.Sorted))
                    throw new InvalidOperationException("Sorting is uncorrected");
                results.Add(res);
                GC.Collect();
            }

            return new SortResult
            {
                Time = results.Average(r => r.Time)
            };

        }

        static bool IsCorrectSorted(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void Register()
        {
            _sorting.Add(new InsertionSort());
            _sorting.Add(new CocktailSort());
            _sorting.Add(new MergeSort());
            _sorting.Add(new ShellSort());
            _sorting.Add(new QuickSort());
            _sorting.Add(new HeapSort());
        }

        static List<int[]> GenerateArrays(int count, int size)
        {
            var arrays = new List<int[]>();
            for (int i = 0; i < count; i++)
            {
                arrays.Add(Generate(size));
            }
            return arrays;
        }

        static int[] Generate(int count)
        {
            var array = new int[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.Next(-100000, 100000);
            }
            return array;
        }
    }
}
