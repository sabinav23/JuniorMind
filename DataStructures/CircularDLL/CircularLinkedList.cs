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
            if (head.Value.Equals(default(T)))
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
            Node<T> node = new Node<T>();

            for (node = head; node.Next != head; node = node.Next)
            {
                yield return node.Value;
            }
            yield return node.Value;

        }

        public bool Remove(Node<T> nodeToRemove)
        {
            if (Count == 1)
            {
                head.Value = default(T);
                head.Prev = head;
                head.Next = head;
                Count--;
                return true;
            }
            Node<T> node = head;
            if (nodeToRemove == head)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
                head = node.Next;
                Count--;
                return true;
            }
            if (!head.Equals(default(T)))
            {
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
            }

            return false;
        }

        public Node<T> Find(T item)
        {
            if (head.Value.Equals(default(T)))
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
            if (head.Value.Equals(default(T)))
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

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (node.Value.Equals(default(T)) && newNode.Value.Equals(default(T)))
            {
                throw new ArgumentNullException();
            }
            else if (node.Equals(head) && Count == 1)
            {
                newNode.Prev = head;
                newNode.Next = head;
                node.Prev = newNode;
                node.Next = newNode;
                head = newNode;
                Count++;
            }
            else
            {
                newNode.Next = node;
                newNode.Prev = node.Prev;
                node.Prev.Next = newNode;
                node.Prev = newNode;
                Count++;
            }
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
            if (head.Value.Equals(default(T)))
            {
                SetHead(node);
            }
            else
            {
                AddBefore(head, node);
            }
        }

        public void AddFirst(T value)
        {
            Node<T> node = CreateNode(value);
            if (head.Value.Equals(default(T)))
            {
                SetHead(node);
            }
            else
            {
                AddBefore(head, node);
            }
        }

        public void AddLast(Node<T> node)
        {
            if (head.Value.Equals(default(T)))
            {
                SetHead(node);
            }
            Node<T> keephead = head;
            AddBefore(head, node);
            head = keephead;
        }

        public void Add(T item)
        {
            Node<T> node = CreateNode(item);
            if (head.Value.Equals(default(T)))
            {
                SetHead(node);
            }
            Node<T> keephead = head;
            AddBefore(head, node);
            head = keephead;
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
            if (head.Value.Equals(default(T)))
            {
                throw new InvalidOperationException();
            }
            else
            {
                Remove(head);
            }
        }

        public void RemoveLast()
        {
            if (head.Value.Equals(default(T)))
            {
                throw new InvalidOperationException();
            }
            else
            {
                Remove(head.Prev);
            }
        }

        public void SetHead(Node<T> node)
        {
            head = node;
            Count++;
        }
    }


}
