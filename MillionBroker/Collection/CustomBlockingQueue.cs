using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MillionBroker.Collection
{
    class ReaderWriterLockSlimBlockingQueue : IOrderQueue
    {
        private ReaderWriterLockSlim Lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private Queue<Order> OrderQueue = new Queue<Order>();

        public void Enqueue(Order order)
        {
            Lock.EnterWriteLock();

            OrderQueue.Enqueue(order);

            Lock.ExitWriteLock();
        }

        public Order Dequeue()
        {
            Lock.EnterReadLock();
            if (OrderQueue.Count > 0)
                return OrderQueue.Dequeue();

            Lock.ExitReadLock();
            return null;

        }
    }

    class ReaderWriterLockBlockingQueue : IOrderQueue
    {
        private ReaderWriterLock Lock = new ReaderWriterLock();

        private Queue<Order> OrderQueue = new Queue<Order>();

        public void Enqueue(Order order)
        {
            Lock.AcquireWriterLock(TimeSpan.FromMilliseconds(1000));

            OrderQueue.Enqueue(order);

            Lock.ReleaseWriterLock();
        }

        public Order Dequeue()
        {
            Lock.AcquireReaderLock(TimeSpan.FromMilliseconds(1000));
            if (OrderQueue.Count > 0)
                return OrderQueue.Dequeue();

            Lock.ReleaseReaderLock();
            return null;

        }
    }

    class MonitorBlockingQueue : IOrderQueue
    {
        private object SyncRoot = new object();
        private Queue<Order> OrderQueue = new Queue<Order>();

        public void Enqueue(Order order)
        {
            lock (SyncRoot)
            {
                OrderQueue.Enqueue(order);
            }
        }

        public Order Dequeue()
        {
            lock (SyncRoot)
            {
                if (OrderQueue.Count > 0)
                    return OrderQueue.Dequeue();

                return null;
            }
        }
    }

}
