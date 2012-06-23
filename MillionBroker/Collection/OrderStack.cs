using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBroker.Collection
{
    class OrderStack : System.Collections.Concurrent.ConcurrentStack<Order>, IOrderQueue
    {
        public void Enqueue(Order order)
        {
            this.Push(order);
        }

        public Order Dequeue()
        {
            Order order;
            this.TryPop(out order);

            return order;
        }
    }
}
