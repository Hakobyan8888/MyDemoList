using System;
using System.Collections.Generic;
using System.Text;

namespace MyDemoList
{
    public interface IMyList<T> : IEnumerable<T>, ICollection<T>
    {
        T this[int index] { get; set; }

        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);
    }
}
