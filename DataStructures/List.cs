using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArrayProject
{
    class List<T> : IList<T>
    {

        public T[] array;

        public List()
        {
            array = new T[4];
        }

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public int Count { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual void Add(T element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            EnsureCapacity();
            MoveElementsToTheRight(index);
            this[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
            Count = 0;
        }
       
        public bool Remove(T element)
        {
            int position = IndexOf(element);
            if (position != -1)
            {
                RemoveAt(position);
                return true;
            }
            return false;
        }
        
        public void RemoveAt(int index)
        {
            MoveElementsToTheLeft(index);
            Count--;
        }

        private void MoveElementsToTheLeft(int position)
        {
            for (int i = position; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void MoveElementsToTheRight(int position)
        {
            for (int i = array.Length - 1; i > position; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void EnsureCapacity()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < arrayIndex + Count; i++)
            {
                array[i] = this.array[i - arrayIndex];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
    }
}
