using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Producer
    {
        private BoundedBuffer _buffer;
        private int _max;

        public Producer(BoundedBuffer buffer, int howManyToProduce)
        {
            _buffer = buffer;
            _max = howManyToProduce;
        }
        public void Run()
        {
            for (int i = 0; i < _max; i++)
            {
                if (i == _max - 1)
                {
                    _buffer.LastObject = i;
                }
                _buffer.Put(i);

            }
        }
    }
}
