using System;

namespace DataStructures.Lib
{

    public class DLinkedList<T>
    {

        private Node<T> head = null;
        private Node<T> last = null;


        public DLinkedList()
        { }

        public void Add(T val) //Adds element at the end of a list
        {
            Node<T> node = new Node<T>();
            node.val = val;


            //first time handle
            if (head == null)
            {
                head = node;
                last = node;
                return;
            }

            node.prev = last;
            last.next = node;
            last = node;
        }

        public void Remove(int index)
        {
            Node<T> curr = head;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == null)
                    throw new IndexOutOfRangeException("Index " + i + " had next element equals to null when trying to go further.");

                curr = curr.next;
            }

            if (curr.prev != null)
                curr.prev.next = curr.next;

            if (curr.next != null)
                curr.next.prev = curr.prev;

            if (curr == head)
                head = curr.next;

            if (curr == last)
                last = curr.prev;
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
            public Node<K> prev = null;
        }


    }





}