using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBroker
{
    enum OrderQueueType : int
    {
        ConcurrentQueue,
        BlockingCollection,
        ConcurrentStack,
        ConcurrentBag,
        MonitorBlockingQueue,
        ReaderWriterLockBlockingQueue,
        ReaderWriterLockSlimBlockingQueue
    }
}
