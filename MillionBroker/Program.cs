using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using MillionBroker.Test;

namespace MillionBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            SetThreading();

            ITest simulator = new CollectionPerformanceTest();
            simulator.Test();
        }

        static void SetThreading() {
            //ThreadPool.SetMinThreads(Consts.MIN_THREAD_SIZE, 0);
            // int workerThreads, IOThreads;
            //ThreadPool.GetAvailableThreads(out workerThreads, out IOThreads);
            //Console.WriteLine(string.Format("Available worker thread count: {0}, Avaliable IO threads count: {1}", workerThreads, IOThreads));
        }

    }
}
