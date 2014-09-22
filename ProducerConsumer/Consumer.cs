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
        private BoundedBuffer _buffer;
        public Consumer(BoundedBuffer buffer)
        {
            _buffer = buffer;
        }
        public void Run()
        {
            for (;;)
            {
                int temp = _buffer.Take();

                if (temp == (int)_buffer.LastObject)
                {
                    break;
                }
            }
            
        }
    }
}
