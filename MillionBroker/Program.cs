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
            ITest simulator = new CollectionPerformanceTest();

            simulator.Test();
        }

    }
}
