namespace Seljmov.CS;

/// <summary>
/// Класс для сортировки
/// </summary>
public static class Sort
{
    private static readonly Random Random = new();

    #region QuickSort

    /// <summary>
    /// Быстрая сортировка
    /// </summary>
    /// <remarks>https://ru.wikipedia.org/wiki/Быстрая_сортировка</remarks>
    /// <param name="array">Сортируемый массив</param>
    public static void QuickSort(int[] array)
    {
        if (array.Length <= 1) return;
        
        QuickSortWrapper(array, 0, array.Length - 1);
    }

    /// <summary>
    /// Обертка для быстрой сортировки
    /// </summary>
    /// <param name="array">Сортируемый массив</param>
    /// <param name="low">Нижняя граница</param>
    /// <param name="high">Верхняя граница</param>
    private static void QuickSortWrapper(int[] array, int low, int high)
    {
        // Если нижняя граница больше или равна верхней, то сортировать нечего
        if (low >= high) return;
        
        // Получаем индекс опорного элемента
        var p = RandomizedPartition(array, low, high);
        // Сортируем левую часть
        QuickSortWrapper(array, low, p);
        // Сортируем правую часть
        QuickSortWrapper(array, p + 1, high);
    }

    /// <summary>
    /// Рандомизированный выбор опорного элемента
    /// </summary>
    /// <param name="array">Сортируемый массив</param>
    /// <param name="low">Нижняя граница</param>
    /// <param name="high">Верхняя граница</param>
    /// <returns>Индекс опорного элемента</returns>
    private static int RandomizedPartition(int[] array, int low, int high)
    {
        // Получаем случайный индекс
        var randomIndex = Random.Next(low, high + 1);
        // Получаем случайный элемент
        var randomItem = array[randomIndex];
        var i = low;
        var j = high;

        // Пока индексы не пересеклись
        while (true)
        {
            // Ищем элемент больше опорного слева
            while (array[i] < randomItem) i++;
            // Ищем элемент меньше опорного справа
            while (array[j] > randomItem) j--;
            // Если индексы пересеклись, то возвращаем индекс опорного элемента
            if (i >= j) return j;
            // Меняем местами элементы
            (array[i], array[j]) = (array[j], array[i]);
            // Сдвигаем индексы
            i++;
            j--;
        }
    }

    #endregion

    #region MergeSort

    /// <summary>
    /// Cортировка слиянием
    /// </summary>
    /// <remarks>https://ru.wikipedia.org/wiki/Сортировка_слиянием</remarks>
    /// <param name="array">Сортируемый массив</param>
    public static void MergeSort(int[] array)
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
        MergeSort(left);
        // Сортируем правую часть
        MergeSort(right);
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

    #endregion
}