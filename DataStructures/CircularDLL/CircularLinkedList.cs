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
            head = new Node<T>();
            head.Value = default(T);
            head.Prev = head;
            head.Next = head;
        }
        public int Count { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Clear()
        {
            head.Value = default(T);
            head.Next = head;
            head.Prev = head;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (head.Next.Value.Equals(item))
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
            if (array == null || head.Next == head)
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
            node = head.Next;
            for (int i = arrayIndex; i < arrayIndex + Count; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = new Node<T>();

            for (node = head.Next; node != head; node = node.Next)
            {
                yield return node.Value;
            }
        }

        public bool Remove(Node<T> nodeToRemove)
        {
            if (Count == 1)
            {
                Clear();
                return true;
            }
            Node<T> node;
            for (node = head.Next; node != head; node = node.Next)
            {
                if (node.Equals(nodeToRemove))
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public Node<T> Find(T item)
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

            return null;
        }

        public Node<T> FindLast(T item)
        {
            Node<T> last = null;
            if (head.Next == head)
            {
                throw new ArgumentNullException();
            }

            Node<T> node = new Node<T>();
            node = head.Next;
            while (node != head)
            {
                if (node.Next.Value.Equals(item))
                {
                    last = node.Next;
                }
                node = node.Next;
            }

            return last;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (newNode.Value.Equals(default(T)))
            {
                throw new ArgumentNullException();
            }
            newNode.Prev = node.Prev;
            newNode.Next = node;
            node.Prev.Next = newNode;
            node.Prev = newNode;
            Count++;           
        }

        public void AddBefore(Node<T> node, T value)
        {
            Node<T> newNode = CreateNode(value);
            AddBefore(node, newNode);
        }

        public void AddFirst(Node<T> node)
        {
            if (node.Value.Equals(default(T)))
            {
                throw new ArgumentNullException();
            }
            
            AddAfter(head, node);
        }

        public void AddFirst(T value)
        {
            Node<T> node = CreateNode(value);
            AddAfter(head, node);
        }

        public void AddLast(Node<T> node)
        {
            AddBefore(head, node);
        }

        public void Add(T item)
        {
            Node<T> node = CreateNode(item);
            AddBefore(head, node);
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            AddBefore(node.Next, newNode);
        }

        public void AddAfter(Node<T> givenNode, T value)
        {
            Node<T> node = CreateNode(value);
            AddBefore(givenNode.Next, node);
        }

        public Node<T> CreateNode(T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;
            node.Prev = node;
            node.Next = node;
            return node;
        }


        public bool Remove(T item)
        {
            Node<T> node = Find(item);
            if (!node.Equals(default(T)))
            {
                Remove(node);
                return true;
            }
            
            return false;
        }

        public void RemoveFirst()
        {
            if (head.Next == head)
            {
                throw new InvalidOperationException();
            }

            Remove(head.Next);
        }

        public void RemoveLast()
        {
            if (head.Next == head)
            {
                throw new InvalidOperationException();
            }

            Remove(head.Prev);
        }
    }


}
