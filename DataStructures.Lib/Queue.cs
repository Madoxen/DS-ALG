using System;

namespace DataStructures.Lib
{
    //Represents First in, first out collection of given capacity
    public class Queue<T>
    {
        private int _first;
        private int _last;
        private int _count = 0;
        private int _cap = 0;
        private T[] _values;


        public Queue(int _cap)
        {
            this._cap = _cap;
            _values = new T[this._cap];
        }


        public void Enqueue(T val)
        {
            if (_count >= _values.Length)
                throw new InvalidOperationException();

            _values[_last] = val;
            _last = (_last + 1) % _cap;
            _count++;
        }

        public T Dequeue()
        {
            if (_count <= 0)
                throw new InvalidOperationException();

            T buff = _values[_first];
            _values[_first] = default(T);
            _first = (_first + 1) % _cap;
            _count--;
            return buff;
        }
    }
}