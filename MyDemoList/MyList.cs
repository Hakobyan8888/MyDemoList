using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyDemoList
{
    class MyList<T> : IMyList<T>
    {
        private T[] _items;
        const int n = 1;

        public MyList(){
            _items = new T[n];
        }

        public MyList(int Length)
        {
            _items = new T[Length];
        }

        public T this[int index] { get => _items[index]; set => _items[index] = value; }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly { get; } = false;

        private void Resize(int max)
        {
            T[] tempItems = new T[max];
            for(int i = 0; i < Count; i++)
            {
                tempItems[i] = _items[i];
            }
            _items = tempItems;
        }

        public void Add(T item)
        {
            if(Count == _items.Length)
            {
                Resize(_items.Length * 2);
            }
            _items[Count++] = item;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            for(int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int j = arrayIndex;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_items[i], j);
                j++;
            }
        }

        public int IndexOf(T item)
        {
            int itemIndex = -1;
            for(int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    itemIndex = i;
                    break;
                }
            }
            return itemIndex;
        }

        public void Insert(int index, T item)
        {
            if((Count+1<=_items.Length) && (index<Count) && (index >= 0))
            {
                Count++;
                for(int i = Count - 1; i > index; i--)
                {
                    _items[i] = _items[i - 1];
                }
                _items[index] = item;
            }
        }

        public bool Remove(T item)
        {
            if(_items is null)
            {
                return false;
            }
            for(int i = 0; i<Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    while (i < Count)
                    {
                        _items[i] = _items[++i];
                    }
                    Count--;
                    break;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for(int i = index; index < Count - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }
                Count--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
