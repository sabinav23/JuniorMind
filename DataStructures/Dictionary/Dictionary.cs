using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Dictionary
{
    class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {    
        private int[] mainArray;
        private EntryContent<TKey, TValue>[] entries;
        private int freeIndex;
        

        public Dictionary(int size = 100)
        {
            mainArray = new int[size];
            entries = new EntryContent<TKey, TValue>[size];
            Array.Fill(mainArray, -1);
            freeIndex = -1;
        }

        public TValue this[TKey key]
        {
            get {
                VerifyIsNull(key);
                int index = Find(key);
                if (index != -1)
                {
                    return entries[index].Value;
                }

                throw new KeyNotFoundException();
            }
            set
            {
                int index = Find(key);
                if (index != -1)
                {
                    entries[index].Value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        private (int index, int previous) FindElement(TKey key)
        {
            int previous = -1;
            int posaition = mainArray[BucketIndex(key)];
            for (int index = posaition; index != -1; index = entries[posaition].Next)
            {
                if (entries[index].Key.Equals(key))
                {
                    return (index, previous);
                }
                previous = index;
            }

            return (-1, -1);
        }

        private int Find(TKey key)
        {
            var (index, _) = FindElement(key);

            return index;
        }  

        public ICollection<TKey> Keys { 
            get
            {
                var list = new List<TKey>();
                var en = this.GetEnumerator();

                while (en.MoveNext())
                {
                    list.Add(en.Current.Key);
                }
               
                return list;
            }          
        }

        public ICollection<TValue> Values {
            get
            {
                var list = new List<TValue>();
                var en = this.GetEnumerator();

                while (en.MoveNext())
                {
                    list.Add(en.Current.Value);
                }
                
                return list;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }            
        }

        public void Add(TKey key, TValue value)
        {
            VerifyIsNull(key);
            int positionInEntiesArray = BucketIndex(key);
            int previousValue = mainArray[positionInEntiesArray];
            int ind;

            if (freeIndex != -1)
            {
                ind = freeIndex;
                freeIndex = entries[freeIndex].Next;
            }
            else
            {
                ind = Count;
            }

            mainArray[positionInEntiesArray] = ind;
            EntryContent<TKey, TValue> entry = new EntryContent<TKey, TValue>
            {
                Key = key,
                Value = value,
                Next = previousValue,
            };
            entries[ind] = entry;
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Fill(mainArray, -1);
            Count = 0;
            freeIndex = -1;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            VerifyIsNull(item.Key);
            int index = Find(item.Key);

            return index != 1 && entries[index].Value.Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            VerifyIsNull(key);
            int index = Find(key);

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

            for (int i = 0; i < arrayIndex + Count; i++)
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
            VerifyIsNull(key);
            (int position, int previousPosition) = FindElement(key);
            if (position == -1)
            {
                return false;
            }
            RemoveItem(key, position,  previousPosition);
            return true;
        }  

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            VerifyIsNull(item.Key);
            (int position, int previousPosition) = FindElement(item.Key);

            if (entries[position].Value.Equals(item.Value))
            {
                RemoveItem(item.Key, position, previousPosition);
                return true;
            }
            return false;
        }

        public bool Remove(TKey key, out TValue value)
        {
            VerifyIsNull(key);
            (int position, int previousPosition) = FindElement(key);
            if (position == -1)
            {
                value = default(TValue);
                return false;
            }
            value = entries[position].Value;
            RemoveItem(key, position, previousPosition);

            return true;
        }

        private void RemoveItem(TKey key, int position, int previousPosition)
        {
            int bucketIndex = BucketIndex(key);
            RemoveAtGivenIndex(position, key);

            if (mainArray[bucketIndex] == position)
            {
               mainArray[bucketIndex] = entries[position].Next;
            }
            else
            {
                entries[previousPosition].Next = entries[position].Next;
            }
        }

        private void RemoveAtGivenIndex(int index, TKey key)
        {
            entries[index].Next = freeIndex;
            freeIndex = index;
            entries[index].Key = default(TKey);
            entries[index].Value = default(TValue);
            Count--;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            VerifyIsNull(key);
            var index = BucketIndex(key);
            int position = Find(key);
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

        public void VerifyIsNull(TKey key)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
