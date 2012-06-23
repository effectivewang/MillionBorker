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
            Thread thread = new Thread(() =>
            {
                Order order = QueueProvider.Instance.Dequeue();
                while (order != null)
                {
                    order.Status = Order.OrderStatus.Processed;
                }

                if (Complete != null)
                    Complete();
            });
            thread.Start();
        }
    }
}
