using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lav._9_6.Pavliy
{
    class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        public void Insert(int index, T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = null;
            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                if (current != null) current = current.Next;
            }
            if (current != null)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }
        public int Count { get { return count; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        internal void RemoveAt(int i) => throw new NotImplementedException();

        internal void Remove(int minNumber)
        {
            throw new NotImplementedException();
        }
    }
}