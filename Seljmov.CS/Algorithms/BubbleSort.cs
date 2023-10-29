namespace Seljmov.CS.Algorithms;

public static class BubbleSort
{
    public static void Do(int[] array)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            for (var j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j]) 
                    (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}