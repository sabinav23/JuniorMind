using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArrayProject
{
    class ObjectArray : IEnumerable
    {
        public Object[] array;

        public ObjectArray()
        {
            this.array = new Object[4];
        }

        public virtual Object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public int Count { get; set; }

        public virtual void Add(Object element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(Object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(Object element)
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

        public virtual void Insert(int index, Object element)
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

        public void Remove(Object element)
        {
            int position = IndexOf(element);
            if (position != -1)
            {
                RemoveAt(position);
            }

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

        public IEnumerator GetEnumerator()
        {
            foreach (Object el in array)
            {
                if (Count > 0)
                {
                    yield return el;
                }
                Count--;              
            }
        }
    }
}
