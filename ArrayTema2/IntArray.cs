using System;
using Xunit;

namespace IntArrayProject
{
    public class IntArray
    {
        public int?[] array;

        public IntArray()
        {
            this.array = new int?[4];
        }

        public void Add(int element)
        {
            int initialLength = array.Length;
            if (array[initialLength - 1].HasValue)
            {
                Array.Resize(ref array, initialLength * 2);
                array[initialLength] = element;
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (!array[i].HasValue)
                    {
                        array[i] = element;
                        break;
                    }
                }
            }
      
        }

        public int Count()
        {
            int count = 0;
            for ( int i = 0; i < array.Length; i++)
            {
                if (array[i].HasValue)
                {
                    count++;
                }
            }
            return count;
        }

        public int? Element(int index)
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
        }

        public bool Contains(int element)
        {
            return ExistsInArray(element) != -1 ? true : false;
        }

        public int IndexOf(int element)
        {
            return ExistsInArray(element);
        }

        public void Insert(int index, int element)
        {

            MoveElements(index, "dr");
            array[index] = element;
        }

        public void Clear()
        {
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].HasValue)
                {
                    array[i] = null;
                }
            }
        }

        public void Remove(int element)
        {
            int position = ExistsInArray(element);
            if (position != -1)
            {
                MoveElements(position, "st");
            }

        }

        public void RemoveAt(int index)
        {
            MoveElements(index, "st");
        }

        private int ExistsInArray(int element)
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

        private void MoveElements(int position, string direction)
        {
            if (direction.Equals("st"))
            {
                for (int i = position; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
            }
            else
            {
                Array.Resize(ref array, array.Length + 1);
                for (int i = array.Length - 1; i >= position; i--) 
                {
                    array[i] = array[i - 1];
                }
            }
        }
    }

}
