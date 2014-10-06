using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Producer
    {
        private BlockingCollection<int> _buffer;
        private int _max;

        public Producer(BlockingCollection<int> buffer, int howManyToProduce)
        {
            _buffer = buffer;
            _max = howManyToProduce;
        }
        public void Run()
        {
            for (int i = 0; i < _max; i++)
            {
                _buffer.Add(i);
                Console.WriteLine("Added {0} to buffer.", i);

                if (i == _max)
                {
                    _buffer.CompleteAdding();
                }
            }
        }
    }
}
