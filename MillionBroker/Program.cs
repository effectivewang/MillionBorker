using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace MillionBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            Array array = Enum.GetValues(typeof(OrderQueueType));
            ManualResetEvent[] resets = new ManualResetEvent[array.Length];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(string.Format("<{0}> Time {0} Performance Statistics", i + 1));
                Header();

                for (int j = 0; j < array.Length; j++)
                {
                    if (resets[j] == null) resets[j] = new ManualResetEvent(false);
                    resets[j].Reset();

                    Experiment((OrderQueueType)(array.GetValue(j)), resets[j]);
                    resets[j].WaitOne();
                }

                EventWaitHandle.WaitAll(resets);

                Console.WriteLine();
            }

            Console.Read();
        }

        static void Experiment(OrderQueueType type, EventWaitHandle waitHandler)
        {
            Stopwatch sw = Stopwatch.StartNew();
            QueueProvider.SetQueueType(type);

            TradeConsole tc = new TradeConsole();
            tc.Execute();

            Broker broker = new Broker();
            broker.Complete = () =>
            {
                sw.Stop();
                Console.WriteLine(string.Format("{1, 35}\t\t\t\t{0}", sw.ElapsedMilliseconds, type.ToString()));

                waitHandler.Set();
            };
            broker.Sell();
        }

        static void Header()
        {
            Console.WriteLine(string.Format("{0}\t\t\t\t\t\t\t{1}", "Structure", "Milliseconds"));
            Console.WriteLine("----------------------------------------\t\t\t--------------------");
        }

    }
}
