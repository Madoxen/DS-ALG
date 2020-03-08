using System;
using System.Diagnostics;

namespace DataStructures.Lib
{
    public class LinkedList<T>
    {

        private Node<T> head = null;
        private Node<T> last = null;


        public LinkedList()
        {
        }

        public void Add(T val)
        {
            Node<T> node = new Node<T>();
            node.val = val;

            if (head == null)
            {
                head = node;
                last = node;
                return;
            }
            last.next = node;
            last = node;
        }

        public void Remove(int index)
        {
            Node<T> curr = head;
            Node<T> prev = null;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == null)
                    throw new IndexOutOfRangeException("Index " + i + " had next element equals to null when trying to go further.");

                prev = curr;
                curr = curr.next;
            }

            if (prev == null) //zero element is being deleted
            {
                head = curr.next;
                return;
            }

            if (curr == last) //last element is being deleted
            {
                last = prev;
                last.next = null;
                return;
            }

            prev.next = curr.next;
            curr.val = default(T);
            curr.next = null;
        }


        private T Get(int index)
        {
            Node<T> curr = head;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == null)
                    throw new IndexOutOfRangeException();

                curr = curr.next;
            }
            return curr.val;
        }

        private void Set(T val, int index)
        {
            Node<T> curr = head;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == null)
                    throw new IndexOutOfRangeException();

                curr = curr.next;
            }
            curr.val = val;
        }



        public T this[int i]
        {
            get { return Get(i); }
            set { Set(value, i); }
        }

        private class Node<K>
        {
            public K val = default(K);
            public Node<K> next = null;
        }
    }
}