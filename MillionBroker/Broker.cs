using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MillionBroker
{
    class Broker
    {
        public Action Complete;

        public Broker()
        {
        }

        public void Sell()
        {
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                Order order = QueueProvider.Instance.Dequeue();
                while (order != null)
                {
                    order.Status = Order.OrderStatus.Processed;
                    order = QueueProvider.Instance.Dequeue();
                }

                if (Complete != null)
                {
                    lock (Complete)
                    {
                        Complete();
                    }
                }
            });
        }
    }
}
