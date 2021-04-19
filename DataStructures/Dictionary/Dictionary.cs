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
        private Node head;
        

        public Dictionary(int size = 100)
        {
            mainArray = new int[size];
            entries = new EntryContent<TKey, TValue>[size];

            head = new Node();
            head.Value = 0;
            head.Next = null;

            PopulateArray(mainArray);
        }

        public TValue this[TKey key]
        {
            get {
                int bucketIndex = mainArray[KeyIndex(key)];
                for (int index = bucketIndex; index != -1; index = entries[bucketIndex].Next)
                {
                    if (entries[index].Key.Equals(key))
                    {
                        return entries[index].Value;
                    }
                }

                throw new KeyNotFoundException();
            }
            set
            {
                int bucketIndex = mainArray[KeyIndex(key)];
                for (int index = bucketIndex; index != -1; index = entries[bucketIndex].Next)
                {
                    if (entries[index].Key.Equals(key))
                    {
                        entries[index].Value = value;
                    }
                }

                Add(key, value);
                Count++;
                entriesCount++;
            }
        }

        public ICollection<TKey> Keys { get; }

        public ICollection<TValue> Values { get; }

        public int Count { get; set; }

        private int entriesCount { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }            
        }

        public void Add(TKey key, TValue value)
        {            
            int bucketIndex = KeyIndex(key);
            int previousValue = mainArray[bucketIndex];
            mainArray[bucketIndex] = Count;
            int ind;

            EntryContent<TKey, TValue> entry = new EntryContent<TKey, TValue>();
            Node current = head.Next;

            if (current != null)
            {
                ind = current.Value;
                head.Next = current.Next;
            }
            else
            {
               ind = entriesCount;
            }

            mainArray[bucketIndex] = ind;
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
            for (int i = 0; i < mainArray.Length; i++)
            {
                mainArray[i] = -1;
            }
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
            head.Next = null;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int bucketIndex = mainArray[KeyIndex(item.Key)];
            for (int index = bucketIndex; index != -1; index = entries[index].Next)
            {
                if (entries[index].Key.Equals(item.Key) && entries[index].Value.Equals(item.Value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            int bucketIndex = mainArray[KeyIndex(key)];
            for (int index = mainArray[KeyIndex(key)]; index != -1; index = entries[index].Next)
            {
                if (entries[index].Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
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


            int i = 0;
            for (int j = 0; j < mainArray.Length; j++)
            {
                if (mainArray[j] != -1)
                {
                    for (int k = mainArray[j]; k != -1; k = entries[k].Next)
                    {
                        array[i] = new KeyValuePair<TKey, TValue>(entries[k].Key, entries[k].Value);
                        i++;
                    }
                }
            }          
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < mainArray.Length; i++)
            {
                if (mainArray[i] != -1)
                {
                    for (int index = mainArray[i]; index != -1; index = entries[index].Next)
                    {
                        var entryContent = entries[index];
                        yield return new KeyValuePair<TKey, TValue>(entryContent.Key, entryContent.Value);
                    }
                }              
            }
        }

        public bool Remove(TKey key)
        {
            var index = KeyIndex(key);
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
            var index = KeyIndex(item.Key);
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
                for (int i = mainArray[index]; i != -1; i = entries[index].Next)
                {
                    if (entries[i].Key.Equals(item.Key) && entries[i].Value.Equals(item.Value))
                    {
                        RemoveElement(i);
                        entries[i - 1].Next = entries[i].Next;
                        AddNode(mainArray[index]);
                        return true;
                    }
                }
            }

            return false;
        }
        public bool Remove(TKey key, out TValue value)
        {
            var index = KeyIndex(key);
            if (entries[mainArray[index]].Key.Equals(key))
            {
                value = entries[mainArray[index]].Value;
                RemoveFirstInBucket(mainArray[index], index);
                AddNode(mainArray[index]);
                return true;
            }
            else
            {
                for (int i = mainArray[index]; i != -1; i = entries[index].Next)
                {
                    if (entries[i].Key.Equals(key))
                    {
                        value = entries[mainArray[index]].Value;
                        RemoveElement(i);
                        entries[i - 1].Next = entries[i].Next;
                        AddNode(mainArray[index]);
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;

        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var index = KeyIndex(key);

            for (int i = mainArray[index]; i != -1; i = entries[index].Next)
            {
                if (entries[i].Key.Equals(key))
                {
                    value = entries[mainArray[index]].Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int KeyIndex(TKey key)
        {
            int hash = key.GetHashCode();
            return hash % mainArray.Length;
        }

        private void PopulateArray(int[] indexArray)
        {
            for (int i = 0; i < indexArray.Length; i++)
            {
                indexArray[i] = -1;
            }
        }

        private bool HasElementToRemove(int index, TKey key)
        {
            if (mainArray[index] == -1)
            {
                return false;
            }
            for (int i = mainArray[index]; i != -1; i = entries[index].Next)
            {
                if (entries[i].Key.Equals(key))
                {
                    AddNode(mainArray[i]);
                    RemoveElement(i);
                    entries[i - 1].Next = entries[i].Next;
                    return true;
                }
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
            AddNode(entriesIndex);
            RemoveElement(entriesIndex);
            mainArray[index] = entries[entriesIndex].Next;

            if (mainArray[index] == -1)
            {
                Count--;
            }

            entries[entriesIndex].Next = -1;
        }

        public void AddNode(int value)
        {
            Node node = new Node();
            node.Value = value;
            node.Next = head.Next;
            head.Next = node;
        }

    }
}
