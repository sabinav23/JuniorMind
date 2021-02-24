using System;
using Xunit;

namespace IntArrayProject
{
    public class IntArray
    {
        public int[] array;

        public IntArray()
        {
            this.array = new int[1];
        }

        public void Add(int element)
        {
            int length = array.Length;
            Array.Resize(ref array, length + 1);
            array[length-1] = element;
        }

        public int Count()
        {
            return array.Length - 1;
        }

        public int Element(int index)
        {
            if (array.Length > index)
            {
                return array[index];
            }

            return -1;
        }

        public void SetElement(int index, int element)
        {
            if (array.Length > index)
            {
                array[index] = element;
            }

            Console.WriteLine("No element at given index");
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < array.Length; i++)
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
            array[index] = element;
        }

        public void Clear()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        public void Remove(int element)
        {
            int position = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    position = i;
                    break;
                }
            }
            if (position != -1)
            {
                for (int i = position; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
            }

        }

        public void RemoveAt(int index)
        {
            if (index < array.Length)
            {
                for (int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
            }
        }
    }
   
}
