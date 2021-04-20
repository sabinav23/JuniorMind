using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dictionary
{
    class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        

        private int[] mainArray;
        private EntryContent<TKey, TValue>[] entries;
        private FreePosition[] freePositions;
        private int freeIndex;
        

        public Dictionary(int size = 100)
        {
            mainArray = new int[size];
            entries = new EntryContent<TKey, TValue>[size];
            freePositions = new FreePosition[size];
            Array.Fill(mainArray, -1);
            freeIndex = -1;
        }

        public TValue this[TKey key]
        {
            get {
                int positionInEntiesArray = mainArray[BucketIndex(key)];
                int index = FindPositionOfElement(positionInEntiesArray, key);
                if (index != -1)
                {
                    return entries[index].Value;
                }

                throw new KeyNotFoundException();
            }
            set
            {
                int positionInEntiesArray = mainArray[BucketIndex(key)];
                int index = FindPositionOfElement(positionInEntiesArray, key);
                if (index != -1)
                {
                    entries[index].Value = value;
                }
            }
        }

        private int FindPositionOfElement(int positionInEntiesArray, TKey key)
        {
            for (int index = positionInEntiesArray; index != -1; index = entries[positionInEntiesArray].Next)
            {
                if (entries[index].Key.Equals(key))
                {
                    return index;
                }
            }

            return -1;
        }

        public ICollection<TKey> Keys { 
            get
            {
                var list = new List<TKey>();
                for (int i = 0; i < mainArray.Length; i++)
                {
                    for (int j = mainArray[i]; j != -1; j= entries[j].Next)
                    {
                        list.Add(entries[j].Key);
                    }
                }

                return list;
            }
            
        }

        public ICollection<TValue> Values {
            get
            {
                var list = new List<TValue>();
                for (int i = 0; i < mainArray.Length; i++)
                {
                    for (int j = mainArray[i]; j != -1; j = entries[j].Next)
                    {
                        list.Add(entries[j].Value);
                    }
                }

                return list;
            }
        }

        public int Count { get; set; }

        public int entriesCount { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }            
        }

        public void Add(TKey key, TValue value)
        {            
            int positionInEntiesArray = BucketIndex(key);
            int previousValue = mainArray[positionInEntiesArray];
            mainArray[positionInEntiesArray] = Count;
            int ind;

            EntryContent<TKey, TValue> entry = new EntryContent<TKey, TValue>();

            if (freeIndex != -1)
            {
                ind = freePositions[0].Value;
                freeIndex = freePositions[0].Next;
            }
            else
            {
               ind = entriesCount;
            }

            mainArray[positionInEntiesArray] = ind;
            entries[ind] = entry;
            entries[ind].Key = key;
            entries[ind].Value = value;
            entries[ind].Next = previousValue;

            Count++;
            entriesCount++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Fill(mainArray, -1);
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] != null)
                {
                    entries[i].Key = default(TKey);
                    entries[i].Value = default(TValue);
                    entries[i].Next = -1;
                }
            }

            Count = 0;
            entriesCount = 0;
            freeIndex = -1;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int positionInEntiesArray = mainArray[BucketIndex(item.Key)];
            int index = FindPositionOfElement(positionInEntiesArray, item.Key);

            return index != 1 && entries[index].Value.Equals(item.Value);

        }

        public bool ContainsKey(TKey key)
        {
            int positionInEntiesArray = mainArray[BucketIndex(key)];
            int index = FindPositionOfElement(positionInEntiesArray, key);

            return index != -1;

        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0 || array.Length < arrayIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length < arrayIndex + Count)
            {
                throw new ArgumentException();
            }

            var en = this.GetEnumerator();
            en.MoveNext();

            for (int i = 0; i < arrayIndex + entriesCount; i++)
            {
                array[i] = en.Current;
                en.MoveNext();
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < mainArray.Length; i++)
            {
                for (int index = mainArray[i]; index != -1; index = entries[index].Next)
                {
                    var entryContent = entries[index];
                    yield return new KeyValuePair<TKey, TValue>(entryContent.Key, entryContent.Value);
                }          
            }
        }

        public bool Remove(TKey key)
        {
            var index = BucketIndex(key);
            if (entries[mainArray[index]].Key.Equals(key))
            {
                RemoveFirstInBucket(mainArray[index], index);
                return true;
            }
            else
            {
                return HasElementToRemove(index, key);
            }
        }  

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var index = BucketIndex(item.Key);
            if (index == -1)
            {
                return false;
            }

            if (entries[mainArray[index]].Key.Equals(item.Key) && entries[mainArray[index]].Value.Equals(item.Value))
            {
                RemoveFirstInBucket(mainArray[index], index);
                return true;
            }
            else
            {
                int positionInEntiesArray = mainArray[index];
                int position = FindPositionOfElement(positionInEntiesArray, item.Key);
                if (position != -1)
                {
                    int previousPositon = GetPreviousIndex(positionInEntiesArray, item.Key);
                    RemoveElement(position);
                    entries[previousPositon].Next = entries[position].Next; 
                    return true;
                }
            }

            return false;
        }

        private int GetPreviousIndex(int positionInEntiesArray, TKey key)
        {
            int prev = -1;
            for (int index = positionInEntiesArray; index != -1; index = entries[positionInEntiesArray].Next)
            {
                if (entries[index].Key.Equals(key))
                {
                    return prev;
                }
                prev = index;
            }

            return -1;
        }

        public bool Remove(TKey key, out TValue value)
        {
            var index = BucketIndex(key);
            if (entries[mainArray[index]].Key.Equals(key))
            {
                value = entries[mainArray[index]].Value;
                RemoveFirstInBucket(mainArray[index], index);
                AddInFreePositionsArray(index);
                return true;
            }
            else
            {
                int positionInEntiesArray = mainArray[index];
                int position = FindPositionOfElement(positionInEntiesArray, key);
                if (position != -1)
                {
                    value = entries[positionInEntiesArray].Value;
                    int previousPositon = GetPreviousIndex(positionInEntiesArray, key);
                    RemoveElement(position);
                    entries[previousPositon].Next = entries[position].Next;
                    AddInFreePositionsArray(positionInEntiesArray);
                    return true;
                }
            }

            value = default(TValue);
            return false;

        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var index = BucketIndex(key);

            int positionInEntiesArray = mainArray[index];
            int position = FindPositionOfElement(positionInEntiesArray, key);
            if (position != -1)
            {
                value = entries[mainArray[index]].Value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int BucketIndex(TKey key)
        {
            int hash = key.GetHashCode();
            return hash % mainArray.Length;
        }

        private bool HasElementToRemove(int index, TKey key)
        {
            if (mainArray[index] == -1)
            {
                return false;
            }

            int positionInEntiesArray = mainArray[index];
            int position = FindPositionOfElement(positionInEntiesArray, key);
            if (position != -1)
            {
                int previousPositon = GetPreviousIndex(positionInEntiesArray, key);
                AddInFreePositionsArray(mainArray[position]);
                RemoveElement(position);
                entries[previousPositon].Next = entries[position].Next;
                return true;
            }

            return false;
        }

        private void RemoveElement(int index)
        {
            entries[index].Key = default(TKey);
            entries[index].Value = default(TValue);
            entriesCount--;
        }

        private void RemoveFirstInBucket(int entriesIndex, int index)
        {
            AddInFreePositionsArray(entriesIndex);
            RemoveElement(entriesIndex);
            mainArray[index] = entries[entriesIndex].Next;

            if (mainArray[index] == -1)
            {
                Count--;
            }

            entries[entriesIndex].Next = -1;
        }

        private void AddInFreePositionsArray(int entriesIndex)
        {
            FreePosition freePosition = new FreePosition();
            if (freeIndex == -1)
            {
                freeIndex++;
                freePositions[freeIndex] = freePosition;
                freePositions[freeIndex].Value = entriesIndex;
                freePositions[freeIndex].Next = -1;
            }
            else
            {
                freeIndex++;
                freePositions[freeIndex] = freePosition;
                freePositions[freeIndex].Value = entriesIndex;
                freePositions[freeIndex].Next = freePositions[0].Next;
            }
        }

    }
}
