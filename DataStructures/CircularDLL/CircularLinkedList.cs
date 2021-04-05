using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CircularDoublyLinkedList
{
    class CircularLinkedList<T> : ICollection<T>
    {

        private Node<T> head;

        public CircularLinkedList()
        {
            head = null;
        }
        public int Count { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void AddFirst(T value)
        {
            Node<T> node = CreateNode(value);
            if (head == null)
            {
                head = node;
                Count++;
            }
            else
            {
                node.Next = head;
                node.Prev = head.Prev;
                head.Prev = node;
                head.Prev.Next = node;
                head = node;
                Count++;
            }
        }

        public void AddBefore(Node<T> givenNode, T value)
        {
            if (head == givenNode)
            {
                AddFirst(value);
            }
            else
            {
                Node<T> node = CreateNode(value);

                node.Prev = givenNode.Prev;
                node.Next = givenNode;
                givenNode.Prev.Next = node;
                givenNode.Prev = node;
                Count++;
            }
        }

        public void AddAfter(Node<T> givenNode, T value)
        {
            Node<T> node = CreateNode(value);

            node.Prev = givenNode;
            node.Next = givenNode.Next;
            givenNode.Next.Prev = node;
            givenNode.Next = node;       
            Count++;
            
        }

        public void RemoveFirst()
        {
            head.Next.Prev = head.Prev;
            head.Prev.Next = head.Next;
            head = head.Next;
            Count--;
        }

        public void RemoveLast()
        {
            if (Count == 1)
            {
                head = null;
                Count = 0;
            }
            else
            {
                head.Prev = head.Prev.Prev;
                head.Prev.Prev.Next = head;
                Count--;
            }
        }


        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (head == null)
            {
                return false;
            }
            if (head.Value.Equals(item))
            {
                return true;
            }
            Node<T> node = new Node<T>();
            node = head;
            while (node.Next != head)
            {
                if (node.Next.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
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


            Node<T> node = new Node<T>();
            array[arrayIndex] = head.Value;
            node = head.Next;
            for (int i = arrayIndex + 1; i < arrayIndex + Count && node != head; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = head;

            while (node.Next != head)
            {
                yield return node.Value;
                node = node.Next;
            }
            yield return node.Value;
        }

        public bool Remove(T item)
        {
           if (item.Equals(head.Value))
            {
                RemoveFirst();
                Count--;
                return true;
            }
           else if (item.Equals(head.Prev.Value))
            {
                RemoveLast();
                Count--;
                return true;
            }
           else
            {
                Node<T> node = new Node<T>();
                node = head;
                while (node.Next != head)
                {
                    if (node.Value.Equals(item))
                    {
                        node.Prev.Next = node.Next;
                        node.Next.Prev = node.Prev;
                        Count--;
                        return true;
                    }
                }
            }

            return false;      
        }

        public Node<T> Find(T item)
        {
            if (head == null)
            {
                throw new ArgumentNullException();
            }
            if (head.Value.Equals(item))
            {
                return head;
            }
            else
            {
                Node<T> node = new Node<T>();
                node = head;
                while (node.Next != head)
                {
                    if (node.Next.Value.Equals(item))
                    {
                        return node.Next;
                    }
                    node = node.Next;
                }
            }
            return null;
        }

        public Node<T> FindLast(T item)
        {
            Node<T> last = null;
            if (head == null)
            {
                throw new ArgumentNullException();
            }
            if (head.Value.Equals(item))
            {
                return head;
            }
            else
            {
                Node<T> node = new Node<T>();
                node = head;
                while (node.Next != head)
                {
                    if (node.Next.Value.Equals(item))
                    {
                        last = node.Next;
                    }
                    node = node.Next;
                }
            }
            return last;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            Node<T> node = new Node<T>();
            node.Value = item;
            if (head == null)
            {
                AddFirst(item);
            }
            else
            {
                node.Prev = head.Prev;
                node.Next = head.Prev.Next;
                head.Prev.Next = node;
                head.Prev = node;
                Count++;
            }
        }

        public Node<T> CreateNode(T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;
            node.Prev = node;
            node.Next = node;
            return node;
        }
    }
}
