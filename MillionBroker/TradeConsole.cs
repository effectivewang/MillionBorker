using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MillionBroker
{
    class TradeConsole
    {
        public SemaphoreSlim Seamphore = new SemaphoreSlim(0);

        private IList<Trader> Traders { get; set; }
        private TradeDataProvider DataProvider { get; set; }

        public TradeConsole()
        {
            DataProvider = new TradeDataProvider();
            Traders = new List<Trader>(Consts.MILLION_COUNT);
        }

        public void Execute()
        {
            for (int i = 0; i < Consts.MILLION_COUNT; i++)
            {
                ThreadPool.QueueUserWorkItem((o) => {

                    MillionBroker.Trader bk = new MillionBroker.Trader();
                    bk.Buy(DataProvider.GetTrades(((int)o) % 2  == 0 ? 1 : 2), 100);

                    Traders.Add(bk);

                    if ((int)o == Consts.MIN_ORDER_COUNT) { 
                        Seamphore.Release();
                    }

                }, i);
            }

            Seamphore.Wait();
        }
    }
}
