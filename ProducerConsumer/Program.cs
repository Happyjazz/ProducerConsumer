using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<int> buf = new BlockingCollection<int>(5);

            Producer prod = new Producer(buf, 100);
            Consumer con = new Consumer(buf);

            Parallel.Invoke(prod.Run, con.Run);

            //Console.ReadKey();
        }
    }
}
