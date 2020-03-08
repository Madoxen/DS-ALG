using System;

namespace DataStructures.Lib
{
    //Represents Last in, first out collection
    public class Queue<T>
    {
        int first;
        int last;
        int count = 0;
        int cap = 0;
        T[] values;


        public Queue(int _cap)
        {
            cap = _cap;
            values = new T[cap];
        }


        public void Enqueue(T val)
        {
            
            if(count >= values.Length)
                throw new InvalidOperationException();

            values[last] = val;
            last = (last+1)%cap;
            count++;
        }

        public T Dequeue()
        {
            if(count <= 0)
                throw new InvalidOperationException();

            T buff = values[first];
            values[first] = default(T);
            first = (first+1)%cap;
            count--;
            return buff;
        } 
    }
}