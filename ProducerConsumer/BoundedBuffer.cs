using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _queue;
        private int _bufferSize;

        public BoundedBuffer(int bufferSize)
        {
            _queue = new Queue<int>();
            _bufferSize = bufferSize;
        }
        public bool IsFull()
        {
            return _queue.Count >= _bufferSize;
        }

        public bool IsEmpty()
        {
            return _queue.Count < 1;
        }

        public int Take()
        {
            lock (_queue)
            {
                while (_queue.Count == 0)
                {
                    //Wait while queue is empty
                    Monitor.Wait(_queue);
                }
                int temp = _queue.Dequeue();
                Console.WriteLine("Consumer took {0} from buffer", temp);
                Monitor.PulseAll(_queue);
                return temp;
            }
            

        }

        public void Put(int intForQueue)
        {
            lock (_queue)
            {
                while (IsFull())
                {
                    Monitor.Wait(_queue);
                }
                
                _queue.Enqueue(intForQueue);
                Console.WriteLine("Producer added: {0} to buffer", intForQueue);

                Monitor.PulseAll(_queue);
            }
        }
    }
}
