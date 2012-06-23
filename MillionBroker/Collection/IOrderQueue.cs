using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBroker
{
    interface IOrderQueue
    {
        void Enqueue(Order order);
        Order Dequeue();
    }
}
