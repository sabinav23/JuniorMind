using System;
using Xunit;

namespace IntArrayProject
{
    public class IntArray
    {
        public int[] array;
        int count = 0;

        public IntArray()
        {
            this.array = new int[4];
        }

        public void Add(int element)
        {
            if (count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            array[count] = element;
            count++;
        }

        public int Count()
        {
            return count;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {

            MoveElementsToTheRight(index);
            array[index] = element;
            count++;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
            count = 0;
        }

        public void Remove(int element)
        {
            int position = IndexOf(element);
            if (position != -1)
            {
                MoveElementsToTheLeft(position);
                count--;
            }

        }

        public void RemoveAt(int index)
        {
            MoveElementsToTheLeft(index);
            count--;
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
            for (int i = array.Length - 1; i >= position; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }

}
