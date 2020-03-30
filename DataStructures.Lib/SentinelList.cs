using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Lib
{
    public class SentinelList<T>
    {
        private Node<T> head = null;
        private Node<T> sentinel = null;

        public SentinelList()
        {
            //Create sentinel node 
            Node<T> sentinel = new Node<T>();
            sentinel.val = default(T);
            head = sentinel;
            this.sentinel = sentinel;
        }

        public void Add(T val) //Adds element at the end of a list
        {
            Node<T> node = new Node<T>();
            node.val = val;

            //first time handle
            if (head == sentinel)
            {
                head = node;
                sentinel.prev = head;
                return;
            }

            //Insert element before sentinel node
            node.prev = sentinel.prev;
            sentinel.prev.next = node; //Connect previous element first
            sentinel.prev = node; //Then senstinel node
            node.next = sentinel; //Then next node for new node
        }

        public void Remove(int index)
        {
            Node<T> curr = head;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == sentinel)
                    throw new IndexOutOfRangeException("Index " + i + " had next element equals to sentinel node when trying to go further.");

                curr = curr.next;
            }


            if (curr.prev != null)
                curr.prev.next = curr.next;

            if (curr.next != null)
                curr.next.prev = curr.prev;

            if (curr == head)
                head = curr.next;

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
            public bool isSentinel = false;
        }
    }
}