using System;
using Xunit;

namespace IntArrayProject
{
    public class IntArray
    {
        public int[] array;

        public IntArray()
        {
            this.array = new int[4];
        }

        public virtual int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public int Count { get; set; }

        public virtual void Add(int element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, int element)
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

        public void Remove(int element)
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

        protected void MoveElementsToTheRight(int position)
        {
            for (int i = array.Length - 1; i > position; i--)
            {
                array[i] = array[i - 1];
            }
        }

        public void EnsureCapacity()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }
    }

}
