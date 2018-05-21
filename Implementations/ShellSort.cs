using System;
using System.Collections.Generic;
using System.Diagnostics;
using SortingAlgorithms.Interfaces;
using SortingAlgorithms.Model;

namespace SortingAlgorithms.Implementations
{
    class ShellSort : ISorting
    {
        public string Name => "Shell sort (Сортировка Шелла)";

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
            var steps = CreateSteps(array.Length);
            for (int i = 0; i < steps.Length; i++)
            {
                for (int j = steps[i]; j < array.Length; j += steps[i])
                {
                    Move(array, j, steps[i]);
                }
            }
            
        }

        private void Move(int[] array, int index, int step)
        {
            var i = index;
            while (i > 0 && array[i] < array[i - step])
            {
                Swap(array, i, i - step);
                i -= step;
            }
        }

        private void Swap(int[] array, int source, int target)
        {
            var temp = array[source];
            array[source] = array[target];
            array[target] = temp;
        }

        private int[] CreateSteps(int length)
        {
            var steps = new List<int>();
            var pow = 2;
            int currentStep = 1;
            while (currentStep < length)
            {
                steps.Add(currentStep);
                currentStep = (int)(Math.Pow(2, pow) - 1);
                pow++;
            }
            steps.Reverse();
            return steps.ToArray();
        }
    }
}
