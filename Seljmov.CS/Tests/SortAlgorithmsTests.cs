using Seljmov.CS.Algorithms;
using Xunit;

namespace Seljmov.CS.Tests;

/// <summary>
/// Тесты алгоритмов сортировки
/// </summary>
public static class SortAlgorithmsTests
{
    private static readonly int[] Sorted = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private static readonly int[] Unsorted = { 9, 1, 6, 2, 5, 4, 0, 3, 7, 8 };
    
    /// <summary>
    /// Тест алгоритма пузырьковой сортировки <see cref="BubbleSort"/>
    /// </summary>
    [Fact]
    public static void BubbleSortTest()
    {
        var array = Unsorted.ToArray();
        BubbleSort.Do(array);
        Assert.Equal(array, Sorted);
    }
    
    /// <summary>
    /// Тест алгоритма быстрой сортировки <see cref="QuickSort"/>
    /// </summary>
    [Fact]
    public static void QuickSortTest()
    {
        var array = Unsorted.ToArray();
        QuickSort.Do(array);
        Assert.Equal(array, Sorted);
    }
    
    /// <summary>
    /// Тест алгоритма сортировки слиянием <see cref="MergeSort"/>
    /// </summary>
    [Fact]
    public static void MergeSortTest()
    {
        var array = Unsorted.ToArray();
        MergeSort.Do(array);
        Assert.Equal(array, Sorted);
    }
}