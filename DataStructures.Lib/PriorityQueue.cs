using System;

namespace DataStructures.Lib
{
    public class PriorityQueue<T>
    {
        int cap;
        int count;
        int priorityNum;

        Queue<T>[] queues;



        public PriorityQueue(int _cap, int _priorityNum)
        {
            cap = _cap;
            queues = new Queue<T>[_priorityNum];
            for (int i = 0; i < _priorityNum; i++)
            {
                queues[i] = new Queue<T>(cap);
            }
            priorityNum = _priorityNum;
        }


        public void Enqueue(T val, int priority)
        {
            if (count >= cap)
                throw new InvalidOperationException("Insufficient capacity.");

            if(priority >= priorityNum)
                throw new IndexOutOfRangeException("Given priority index was out of bounds.");
            queues[priority].Enqueue(val);
            count++;
        }

        public T Dequeue()
        {
            if (count <= 0)
                throw new InvalidOperationException();


            for (int i = priorityNum-1; i >= 0; i--)
            {
                try
                {
                    count--;
                    T buff = queues[i].Dequeue();
                    return buff;
                }
                catch (InvalidOperationException e)
                {}
            }
            throw new Exception("All queues were empty, impossible situation (?) ");
        }
    }
}