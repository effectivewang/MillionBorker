using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBroker
{
    class Order
    {

        public enum OrderStatus : int
        {
            Unknown = 0,
            Buy,
            Processed,
            UnProcessed       
        }

        public int OrderID { get; set; }
        public Trade TradeData { get; set; }
        public int Share { get; set; }
        public OrderStatus Status { get; set; }
    }
}
