using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MillionBroker.Collection
{
    class ReaderWriterLockSlimBlockingQueue : IOrderQueue
    {
        private ReaderWriterLockSlim Lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        private Queue<Order> OrderQueue = new Queue<Order>();

        public void Enqueue(Order order)
        {
            Lock.EnterWriteLock();

            OrderQueue.Enqueue(order);

            Lock.ExitWriteLock();
        }

        public Order Dequeue()
        {
            Lock.EnterWriteLock();
            Order order = null;
            if (OrderQueue.Count > 0) {
                order = OrderQueue.Dequeue();
            }

            Lock.EnterWriteLock();

            return order;
        }
    }

    class ReaderWriterLockBlockingQueue : IOrderQueue
    {
        private ReaderWriterLock Lock = new ReaderWriterLock();

        private Queue<Order> OrderQueue = new Queue<Order>();

        public void Enqueue(Order order)
        {
            Lock.AcquireWriterLock(-1);

            OrderQueue.Enqueue(order);

            Lock.ReleaseWriterLock();
        }

        public Order Dequeue()
        {
            Lock.AcquireReaderLock(-1);
            Order order = null;
            if (OrderQueue.Count > 0) { 
                order = OrderQueue.Dequeue();
            }
            Lock.ReleaseReaderLock();

            return order;

        }
    }

    class MonitorBlockingQueue : IOrderQueue
    {
        private Queue<Order> OrderQueue = new Queue<Order>();

        public void Enqueue(Order order)
        {
            lock (OrderQueue)
            {
                OrderQueue.Enqueue(order);
            }
        }

        public Order Dequeue()
        {
            lock (OrderQueue)
            {
                if (OrderQueue.Count > 0)
                    return OrderQueue.Dequeue();

                return null;
            }
        }
    }

}
