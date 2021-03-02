using System;
using System.Collections.Generic;
using System.Text;

namespace IntArrayProject
{
    class SortedIntArray : IntArray
    {
        public override void Add(int element)
        {
            EnsureCapacity();
            AddInSortedOrder(element);
            Count++;
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
                EnsureCapacity();
                InsertElementAtCorrectPosition(position, element);
                Count++;
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
                InsertElementAtCorrectPosition(position, element);
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

        private void InsertElementAtCorrectPosition(int position, int element)
        {
            MoveElementsToTheRight(position);
            this[position] = element;
        }
    }
}

