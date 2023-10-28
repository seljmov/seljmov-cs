namespace Seljmov.CS;

public static class Sort
{
    private static readonly Random Random = new();

    #region QuickSort

    public static void QuickSort(int[] array)
    {
        if (array.Length <= 1) return;
        
        QuickSortWrapper(array, 0, array.Length - 1);
    }

    private static void QuickSortWrapper(int[] array, int low, int high)
    {
        if (low < high)
        {
            var p = RandomizedPartition(array, low, high);
            QuickSortWrapper(array, low, p);
            QuickSortWrapper(array, p + 1, high);
        }
    }

    private static int RandomizedPartition(int[] array, int low, int high)
    {
        var randomIndex = Random.Next(low, high + 1);
        var randomItem = array[randomIndex];
        var i = low;
        var j = high;

        while (true)
        {
            while (array[i] < randomItem) i++;
            while (array[j] > randomItem) j--;
            if (i >= j) return j;
            (array[i], array[j]) = (array[j], array[i]);
            i++;
            j--;
        }
    }

    #endregion

    #region MergeSort

    public static void MergeSort(int[] array)
    {
        if (array.Length <= 1) return;

        var n = array.Length / 2;
        var left = new int[n];
        var right = new int[array.Length - n];

        for (var i = 0; i < n; i++)
            left[i] = array[i];

        for (var i = n; i < array.Length; i++)
            right[i - n] = array[i];
            
        MergeSort(left);
        MergeSort(right);
        Merge(array, left, right);
    }

    private static void Merge(int[] arr, int[] left, int[] right)
    {
        var i = 0;
        var j = 0;
        var n = left.Length + right.Length;
        for (var k = 0; k < n; k++)
        {
            if (i < left.Length && (j >= right.Length || left[i] <= right[j]))
            {
                arr[k] = left[i++];
            }
            else
            {
                arr[k] = right[j++];
            }
        }
    }

    #endregion
}