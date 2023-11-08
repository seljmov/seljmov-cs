namespace Seljmov.CS.Structures;

public class OwnArray<T>
{
    private T[]? _array;
    private int _size = 0;
    private int _capacity = 0;

    public OwnArray(int capacity = 0)
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        if (capacity == 0) return;

        _capacity = capacity;
        _array = new T[_capacity];
    }

    public int Capacity => _capacity;

    public int Size => _size;

    public void Add(T item)
    {
        Resize();
        _array![_size++] = item;
    }

    public T At(int index)
    {
        if (_array is null) throw new Exception();

        return _array[index];
    }

    public void Clear()
    {
        _size = 0;
        _capacity = 0;
        _array = null;
    }

    private void Resize()
    {
        if (_size == 0)
        {
            _capacity = 4;
            _array = new T[4];
            return;
        }

        if (_size+1 > _capacity) 
        {
            _capacity *= 2;
            var newArray = new T[_capacity];
            for (int i = 0; i <= _size; i++)
            {
                newArray[i] = _array![i];
            }
            _array = newArray;
            return;
        }
    }
}

