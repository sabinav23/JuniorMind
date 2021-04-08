using System;
using System.Collections.Generic;
using Xunit;

namespace CircularDoublyLinkedList
{
    public class CircularLinkedListFacts
    {
        [Fact]
        public void AddsFirst()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);

            Assert.True(list.Contains(5));

        }

        [Fact]
        public void AddsFirstUsingNode()
        {
            var list = new CircularLinkedList<int>();
            Node<int> newNode = new Node<int>();
            newNode.Value = 5;
            list.AddFirst(newNode);

            Assert.True(list.Contains(5));

        }


        [Fact]
        public void AddsFirstFromMany()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(7);
            list.AddFirst(8);

            Assert.True(list.Contains(5));
            Assert.True(list.Contains(7));
            Assert.True(list.Contains(8));
        }

        [Fact]
        public void InsertBeforeNode()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(7);
            list.AddFirst(5);

            var node = list.Find(7);
            var value = 2;
            list.AddBefore(node, value);
            Assert.True(list.Count == 3);
            IEnumerator<int> en = list.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(5, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(2, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(7, en.Current);
        }

        [Fact]
        public void InsertAfterNode()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(7);

            var node = list.Find(7);
            var newNode = new Node<int>();
            newNode.Value = 2;
            list.AddAfter(node, newNode);

            Assert.True(list.Count == 3);
            IEnumerator<int> en = list.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(7, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(2, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(5, en.Current);
        }

        [Fact]
        public void RemoveNode()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(2);
            list.Add(5);

            Node<int> node = new Node<int>();
            node.Value = 7;
            list.AddLast(node);
            list.Remove(node);

            Assert.True(list.Count == 2);
        }

        [Fact]
        public void RemoveSingleNode()
        {
            var list = new CircularLinkedList<int>();

            Node<int> node = new Node<int>();
            node.Value = 7;
            list.AddFirst(node);
            list.Remove(node);

            Assert.True(list.Count == 0);
        }

        [Fact]
        public void RemoveFirstValue()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(7);
            list.AddFirst(2);
            list.Remove(2);

            Assert.True(list.Count == 2);
        }

        [Fact]
        public void AddsAtTheEnd()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(7);

            Node<int> node = new Node<int>();
            node.Value = 2;
            list.AddLast(node);

            Assert.True(list.Count == 3);
            Assert.True(list.Contains(5));       
            Assert.True(list.Contains(7));
            Assert.True(node.Prev.Value == 5);
        }

        [Fact]
        public void AddsByValueAtTheEnd()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(7);

            list.Add(2);
            Assert.True(list.Count == 3);
            Assert.True(list.Contains(5));
            Assert.True(list.Contains(7));
            Assert.True(list.Contains(2));
        }
        
        [Fact]
        public void ClearList()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.Add(7);

            list.Clear();

            Assert.True(list.Count == 0);
        }

        [Fact]
        public void ContainsFunctionReturnsTrueWhenElementExistsInList()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.Add(7);

            Assert.True(list.Contains(7));
        }

        [Fact]
        public void FindFirstOfValue()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.Add(7);

            var node = list.Find(7);

            Assert.True(node.Value == 7);
        }

        [Fact]
        public void FindLastOfValue()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.Add(7);
            list.Add(2);
            list.Add(7);
            list.Add(7);

            var node = list.Find(7);
            var lastNode = list.FindLast(7);

            Assert.False(node.Equals(lastNode));
        }
        
        [Fact]
        public void InsertBefore()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.Add(7);

            var node = list.Find(7);
            list.AddBefore(node, 2);
            var node2 = list.Find(2);
            list.AddBefore(node2, 8);

            Assert.True(list.Count == 4);

            IEnumerator<int> en = list.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(5, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(8, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(2, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(7, en.Current);
        }
        
        [Fact]
        public void InsertAfter()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.Add(7);
            list.Add(8);

            var node = list.Find(7);
            list.AddAfter(node, 2);

            Assert.True(list.Count == 4);
            Assert.True(node.Prev.Value == 5);
            Assert.True(node.Next.Value == 2);
        }

        [Fact]
        public void RemoveFirst()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(5);
            list.Add(7);
            list.Add(8);

            list.RemoveFirst();

            Assert.True(list.Count == 2);
            Assert.True(list.Contains(7));
            Assert.True(list.Contains(8));
            Assert.False(list.Contains(5));
        }

        [Fact]
        public void Remove()
        {
            var list = new CircularLinkedList<int>();
            list.AddFirst(8);
            list.Add(7);
            list.Add(8);
            list.Add(7);
            list.Add(2);


            list.RemoveFirst();

            Assert.True(list.Count == 4);
            Assert.True(list.Contains(7));
            Assert.True(list.Contains(8));
            Assert.True(list.Contains(2));
        }
        [Fact]
        public void CopyTo()
        {
            var list = new CircularLinkedList<int>();
            var arr = new int[10];
            list.Add(8);
            list.Add(7);
            list.Add(8);
            list.Add(7);
            list.Add(2);

            list.CopyTo(arr, 1);
            Assert.True(arr[0] == 0);
            Assert.True(arr[1] == 8);
            Assert.True(arr[2] == 7);
            Assert.True(arr[3] == 8);
            Assert.True(arr[4] == 7);
            Assert.True(arr[5] == 2);
        }

        [Fact]
        public void FunctionReturnsTrueWhenArrayHasElementsAtEveryIndex()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);

            IEnumerator<int> en = list.GetEnumerator();

            Assert.True(en.MoveNext());
            Assert.Equal(6, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(7, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(8, en.Current);
            Assert.True(en.MoveNext());
            Assert.Equal(9, en.Current);
            Assert.False(en.MoveNext());
        }
        


    }
}
