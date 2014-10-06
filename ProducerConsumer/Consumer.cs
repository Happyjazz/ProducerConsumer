using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Consumer
    {
        private BlockingCollection<int> _buffer;
        public Consumer(BlockingCollection<int> buffer)
        {
            _buffer = buffer;
        }
        public void Run()
        {
            while (!_buffer.IsCompleted)
            {
                int temp = -1;
                try
                {
                    temp = _buffer.Take();
                }
                catch (InvalidOperationException) { }

                if (temp != null)
                {
                    Console.WriteLine("Took {0} from buffer.",temp);
                }
            }
            Console.WriteLine("Buffer empty.");
        }
    }
}
