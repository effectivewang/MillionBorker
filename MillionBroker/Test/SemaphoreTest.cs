using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

namespace MillionBroker.Test
{
    class SemaphoreSlimTest : ITest
    {
        private SemaphoreSlim _semaphore;

        private SemaphoreSlim Sem
        {
            [MethodImpl( MethodImplOptions.Synchronized )  ]
            get {
                if (_semaphore == null) {
                    _semaphore = new SemaphoreSlim(3);
                }

                return _semaphore;
            }
        }

        public void Test()
        {
            for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);
        }

        private void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            Sem.Wait();
            Console.WriteLine(id + " is in!");           // Only three threads
            Thread.Sleep(1000 * (int)id);               // can be here at
            Console.WriteLine(id + " is leaving");       // a time.
            Sem.Release();
        }
    }
}
