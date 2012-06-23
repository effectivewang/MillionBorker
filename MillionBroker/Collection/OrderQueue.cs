using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace MillionBroker
{
    class ConcurrentOrderQueue : ConcurrentQueue<Order>, IOrderQueue
    {
        public Order Dequeue()
        {
            Order order = null;
            this.TryDequeue(out order);

            return order;
        }
    }
}
