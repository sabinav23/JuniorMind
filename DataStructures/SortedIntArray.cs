using System;
using System.Collections.Generic;
using System.Text;

namespace IntArrayProject
{
    class SortedIntArray : IntArray
    {
        public override void Add(int element)
        {
            int position = FindIndexForElement(element);
            base.Insert(position, element);
        }

        public override int this[int index] { get => base[index];  set
            {
                if (index == FindIndexForElement(value))
                {
                    base[index] = value;
                }
            }
        }

        public override void Insert(int index, int element)
        {
            int position = FindIndexForElement(element);
            if (position == index)
            {
                base.Insert(index, element);
            }
        }

        private void AddInSortedOrder(int element)
        {
            if (Count == 0)
            {
                this[Count] = element;
            }
            else
            {
                int position = FindIndexForElement(element);
                base.Insert(position, element);
            }
        }

        private int FindIndexForElement(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] > element)
                {
                    return i;
                }
            }

            return Count;
        }
    }
}

