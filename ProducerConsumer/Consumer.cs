using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Consumer
    {
        private int _max;
        private BoundedBuffer _buffer;
        public Consumer(BoundedBuffer buffer, int ExpectedAmount)
        {
            _buffer = buffer;
            _max = ExpectedAmount;
        }
        public void Run()
        {
            for (int i = 0; i < _max; i++)
            {
                int temp = _buffer.Take();
                
            }
        }
    }
}
