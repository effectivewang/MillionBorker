using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBroker
{
    class Trade
    {
        public int TradeID { get; set; }
        public string SymbolName { get; set; }

        public override string ToString()
        {
            return string.Format("TradeID: {0}, Symbol: {1}", TradeID, SymbolName);
        }
    }
}
