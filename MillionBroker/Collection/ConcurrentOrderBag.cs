using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBroker.Collection
{
    class ConcurrentOrderBag : System.Collections.Concurrent.ConcurrentBag<Order>, IOrderQueue
    {
        public void Enqueue(Order order)
        {
            this.Add(order);
        }

        public Order Dequeue()
        {
            Order order = null;
            base.TryTake(out order);

            return order;
        }
    }
}
