using System;

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
        }

        public void Remove(int index)
        {
            Node<T> curr = head;
            Node<T> prev = null;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == null)
                    throw new IndexOutOfRangeException();
                prev = curr;
                curr = curr.next;
            }
            if (prev == null)
            {
                head = curr.next;
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