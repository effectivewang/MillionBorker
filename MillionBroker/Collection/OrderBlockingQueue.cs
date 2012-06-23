using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MillionBroker
{
    class OrderBlockingQueue : System.Collections.Concurrent.BlockingCollection<Order>, IOrderQueue
    {
        public void Enqueue(Order order)
        {
            this.TryAdd(order);
        }

        public Order Dequeue()
        {
            Order order;
            this.TryTake(out order, TimeSpan.FromMilliseconds(300));

            return order;
        }
    }
}
