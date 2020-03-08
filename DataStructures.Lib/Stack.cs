using System;

namespace DataStructures.Lib
{
    public class Stack<T>
    {
        T[] values;
        private int _count = 0;
        public int Count
        {
            get {return _count;}
        }


        public Stack(int cap)
        {
            values = new T[cap];
        }

        public void Push(T val)
        {
            if (_count == values.Length)
                throw new InvalidOperationException();
            values[_count] = val;
            _count++;
        }

        public T Pop()
        {
            if(_count <= 0)
                throw new InvalidOperationException();
            T buff = values[_count-1];
            values[_count-1] = default(T);
            _count--;
            return buff;
        }

        public T Peek()
        {
            if(_count <= 0)
                throw new InvalidOperationException();
            return values[_count-1];
        }
    }

}
