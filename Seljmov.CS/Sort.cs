namespace Seljmov.CS;

public class Sort
{
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
}