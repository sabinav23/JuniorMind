using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArrayProject
{

    class ReadOnlyList<T> : IList<T>
    {
        IList<T> list;

        public ReadOnlyList(IList<T> list)
        {
            this.list = list;
        }

        public T this[int index] 
        {
            get => list[index]; 

            set {
                throw new InvalidOperationException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public void Add(T item)
        {
            throw new InvalidOperationException();
        }

        public void Clear()
        {
            throw new InvalidOperationException();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            throw new InvalidOperationException();
        }

        public bool Remove(T item)
        {
            throw new InvalidOperationException();
        }

        public void RemoveAt(int index)
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
