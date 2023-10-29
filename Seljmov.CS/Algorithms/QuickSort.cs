namespace Seljmov.CS.Algorithms;

/// <summary>
/// Реализация быстрой сортировки
/// </summary>
public static class QuickSort
{
    private static readonly Random Random = new();

    /// <summary>
    /// Быстрая сортировка
    /// </summary>
    /// <remarks>https://ru.wikipedia.org/wiki/Быстрая_сортировка</remarks>
    /// <param name="array">Сортируемый массив</param>
    public static void Do(int[] array)
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
}