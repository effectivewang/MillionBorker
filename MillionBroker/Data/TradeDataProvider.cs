using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace MillionBroker
{
    class TradeDataProvider
    {

        public IList<Trade> GetTrades(int count)
        {
            //Debug.WriteLine(string.Format("Thread {0} wants to get the trades.", Thread.CurrentThread.ManagedThreadId));


            Debug.WriteLine(string.Format("Thread {0} is getting the trades.", Thread.CurrentThread.ManagedThreadId));

            IList<Trade> trades = TradeCache.GetCache(count);

            //Debug.WriteLine(string.Format("Thread {0} have got the trades, leaving.", Thread.CurrentThread.ManagedThreadId));


            return trades;
        }
    }

    class TradeCache {

        private static readonly List<Trade> Cache = new List<Trade>(Consts.MAX_CACHE_ITEM_LENGTH);

        static TradeCache() {
            for (int i = 0; i < Consts.MAX_CACHE_ITEM_LENGTH; i++)
            {
                Trade t = TradeGenerator.Generate();
                Cache.Add(t);            
            }
        }

        public static IList<Trade> GetCache(int count)
        {
            lock (Cache)
            {
                if (Cache.Count >= count)
                {
                    return Cache.GetRange(0, count);
                }
                else
                {
                    for (int i = 0; i < count - Cache.Count; i++)
                    {
                        Trade t = TradeGenerator.Generate();
                        Cache.Add(t);

                        //Debug.WriteLine(string.Format("Thread {0} is having trade: {1}", Thread.CurrentThread.ManagedThreadId, t.ToString()));
                    }

                    return Cache;
                }
            }
        }
    }

    class TradeGenerator
    {
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

        public static Trade Generate()
        {
            Trade t = new Trade();

            t.SymbolName = Symbols[_tradeID % Symbols.Length];
            t.TradeID = Interlocked.Increment(ref _tradeID); ;


            return t;
        }
    }
}
