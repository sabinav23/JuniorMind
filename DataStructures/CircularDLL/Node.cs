using System;
using System.Collections.Generic;
using System.Text;

namespace CircularDoublyLinkedList
{
    class Node<T> {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node<T> Prev { get; set; }
        public CircularLinkedList<T> List { get; set; }

    }
}
