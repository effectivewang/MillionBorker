using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBroker
{
    class Trader
    {
        public void Buy(IEnumerable<Trade> trades, int share)
        {
            foreach (Trade t in trades)
            {
                Order o = new Order();
                o.OrderID = OrderDataProvider.OrderID++;
                o.TradeData = t;
                o.Status = Order.OrderStatus.Buy;

                QueueProvider.Instance.Enqueue(o);
            }
        }
    }
}
