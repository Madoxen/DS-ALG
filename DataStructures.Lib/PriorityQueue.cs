using System;

namespace DataStructures.Lib
{
    public class PriorityQueue<T>
    {
        private int _cap;
        private int _count;
        private int _priorityNum;

        private Queue<T>[] _queues;



        public PriorityQueue(int _cap, int _priorityNum)
        {
            if(_priorityNum <= 0)
                throw new ArgumentException("Number of priorities cannot be smaller than 1");

            this._cap = _cap;
            _queues = new Queue<T>[_priorityNum];
            for (int i = 0; i < _priorityNum; i++)
            {
                _queues[i] = new Queue<T>(this._cap);
            }
            this._priorityNum = _priorityNum;
        }


        public void Enqueue(T val, int priority)
        {
            if (_count >= _cap)
                throw new InvalidOperationException("Insufficient capacity.");

            if (priority >= _priorityNum)
                throw new IndexOutOfRangeException("Given priority index was out of bounds.");

            _queues[priority].Enqueue(val);
            _count++;
        }

        public T Dequeue()
        {
            if (_count <= 0)
                throw new InvalidOperationException();

            for (int i = _priorityNum - 1; i >= 0; i--)
            {
                try
                {
                    T buff = _queues[i].Dequeue();
                    _count--;
                    return buff;
                }
                catch (InvalidOperationException) { }
            }

            throw new Exception("All queues were empty, impossible situation since count must have been > 0 at the beginning ");
        }
    }
}