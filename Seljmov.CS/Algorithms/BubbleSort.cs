namespace Seljmov.CS.Algorithms;

/// <summary>
/// Реализация пузырьковой сортировки
/// </summary>
public static class BubbleSort
{
    /// <summary>
    /// Пузырьковая сортировка
    /// </summary>
    /// <remarks>https://ru.wikipedia.org/wiki/Сортировка_пузырьком</remarks>
    /// <param name="array">Сортируемый массив</param>
    public static void Do(int[] array)
    {
        // Основной цикл
        for (var i = 0; i < array.Length - 1; i++)
        {
            // Вложенный цикл
            for (var j = i + 1; j < array.Length; j++)
            {
                // Если элементы стоят в неправильном порядке, то меняем их местами
                if (array[i] > array[j]) 
                    (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}