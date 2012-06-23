using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBroker
{
    class TradeDataProvider
    {
        public IList<Trade> GetTrades(int count) {
            IList<Trade> trades = new List<Trade>(count);
            return trades;
        }
    }
    
    class TradeGenerator {
        private static int _tradeID;

        private static string[] Symbols = new string[10] {
            "IBM",
            "DELL",
            "MSFT",
            "AAPL",
            "INTL",
            "AMD",
            "ADOBE",
            "GOOGLE",
            "FACEBOOK",
            "AMAZON"
        };

        public static Trade Generate() {
            Trade t = new Trade();
            t.SymbolName = Symbols[_tradeID % Symbols.Length];
            t.TradeID = _tradeID++;

            return t;
        }
    }
}
