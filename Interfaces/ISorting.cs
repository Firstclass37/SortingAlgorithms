using SortingAlgorithms.Model;

namespace SortingAlgorithms.Interfaces
{
    public interface ISorting
    {
        string Name { get; }

        SortResult Sort(int[] array);
    }
}
