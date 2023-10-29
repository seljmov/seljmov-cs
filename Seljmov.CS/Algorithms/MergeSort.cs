namespace Seljmov.CS.Algorithms;

/// <summary>
/// Реализация сортировки слиянием
/// </summary>
public static class MergeSort
{
    /// <summary>
    /// Cортировка слиянием
    /// </summary>
    /// <remarks>https://ru.wikipedia.org/wiki/Сортировка_слиянием</remarks>
    /// <param name="array">Сортируемый массив</param>
    public static void Do(int[] array)
    {
        MergeSortWrapper(array);
    }
    
    /// <summary>
    /// Обертка сортировки слиянием
    /// </summary>
    /// <remarks>https://ru.wikipedia.org/wiki/Сортировка_слиянием</remarks>
    /// <param name="array">Сортируемый массив</param>
    private static void MergeSortWrapper(int[] array)
    {
        // Если массив состоит из одного элемента, то сортировать нечего
        if (array.Length <= 1) return;

        // Разбиваем массив на две части
        var n = array.Length / 2;
        var left = new int[n];
        var right = new int[array.Length - n];

        // Копируем элементы в новые массивы
        for (var i = 0; i < n; i++)
            left[i] = array[i];

        for (var i = n; i < array.Length; i++)
            right[i - n] = array[i];

        // Сортируем левую часть
        MergeSortWrapper(left);
        // Сортируем правую часть
        MergeSortWrapper(right);
        // Сливаем отсортированные части
        Merge(array, left, right);
    }

    /// <summary>
    /// Слияние двух массивов
    /// </summary>
    /// <param name="array">Сортируемый массив</param>
    /// <param name="left">Левая часть</param>
    /// <param name="right">Правая часть</param>
    private static void Merge(int[] array, int[] left, int[] right)
    {
        var i = 0;
        var j = 0;
        var n = left.Length + right.Length;
        for (var k = 0; k < n; k++)
        {
            // Если элементы в левой части закончились или элемент в левой части меньше элемента в правой части
            if (i < left.Length && (j >= right.Length || left[i] <= right[j]))
            {
                array[k] = left[i++];
            }
            else
            {
                array[k] = right[j++];
            }
        }
    }
}