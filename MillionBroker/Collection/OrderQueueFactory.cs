using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MillionBroker.Collection;

namespace MillionBroker
{
    class OrderQueueFactory
    {
        public static IOrderQueue Create(OrderQueueType type)
        {
            switch (type) { 
                case OrderQueueType.ConcurrentQueue:
                    return new ConcurrentOrderQueue();
                case OrderQueueType.BlockingCollection:
                    return new OrderBlockingQueue();
                case OrderQueueType.ConcurrentStack:
                    return new OrderStack();
                case OrderQueueType.ConcurrentBag:
                    return new ConcurrentOrderBag();
                case OrderQueueType.MonitorBlockingQueue:
                    return new MonitorBlockingQueue();
                case OrderQueueType.ReaderWriterLockBlockingQueue:
                    return new ReaderWriterLockBlockingQueue();
                case OrderQueueType.ReaderWriterLockSlimBlockingQueue:
                    return new ReaderWriterLockSlimBlockingQueue();
                default:
                    return null;
            }
        }
    }
}
