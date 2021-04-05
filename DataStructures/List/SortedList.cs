using System;
using System.Collections.Generic;
using System.Text;

namespace IntArrayProject
{
    class SortedList<T> : List<T> where T : IComparable<T>
    {
        public override void Add(T element)
        {
            int position = FindIndexForElement(element);
            base.Insert(position, element);
        }

        public override T this[int index] { get => base[index];  set
            {
                if (index == FindIndexForElement(value))
                {
                    base[index] = value;
                }
            }
        }

        public override void Insert(int index, T element)
        {
            int position = FindIndexForElement(element);
            if (position == index)
            {
                base.Insert(index, element);
            }
        }

        private void AddInSortedOrder(T element)
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

        private int FindIndexForElement(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(element) > 0)
                {
                    return i;
                }
            }

            return Count;
        }
    }
}

