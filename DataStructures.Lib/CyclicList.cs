using System;

namespace DataStructures.Lib
{

    public class CyclicList<T>
    {

        private Node<T> head = null;
        private Node<T> last = null;


        public CyclicList()
        { }

        public void Add(T val) //Adds element at the end of a list
        {
            Node<T> node = new Node<T>();
            node.val = val;

            if (head == null)
            {
                head = node;
                head.next = head;
                last = node;
                return;
            }

            last.next = node;
            last = node;
            last.next = head; //set cyclic reference
        }

        public void Remove(int index)
        {
            Node<T> curr = head;
            Node<T> prev = null;

            for (int i = 0; i < index; i++)
            {
                prev = curr;
                curr = curr.next;
            }


            if (curr == head)
            {
                prev = last;
                head = head.next;
                if (head == head.next)
                {
                    head = null;
                    return;
                }
            }

            prev.next = curr.next;
            curr = null;
        }


        private T Get(int index)
        {
            if(head == null)
                throw new Exception("Collection is empty");
                
            Node<T> curr = head;
            for (int i = 0; i < index; i++)
            {
                curr = curr.next;
            }
            return curr.val;
        }

        private void Set(T val, int index)
        {
            Node<T> curr = head;
            for (int i = 0; i < index; i++)
            {
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