using System;

namespace DataStructures.Lib
{
    public class Stack<T>
    {
        private T[] _values;
        private int _count = 0;
        public int Count
        {
            get { return _count; }
        }


        public Stack(int cap)
        {
            _values = new T[cap];
        }

        public void Push(T val)
        {
            if (_count == _values.Length)
                throw new InvalidOperationException();
            _values[_count] = val;
            _count++;
        }

        public T Pop()
        {
            if (_count <= 0)
                throw new InvalidOperationException();
            T buff = _values[_count - 1];
            _values[_count - 1] = default(T);
            _count--;
            return buff;
        }

        public T Peek()
        {
            if (_count <= 0)
                throw new InvalidOperationException();
            return _values[_count - 1];
        }
    }
}
