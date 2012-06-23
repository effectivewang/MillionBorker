using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MillionBroker
{
    class TradeConsole
    {
        private IList<Trader> Traders { get; set; }

        private TradeDataProvider DataProvider { get; set; }

        public TradeConsole()
        {
            DataProvider = new TradeDataProvider();
            Traders = new List<Trader>(Consts.BILLION_COUNT);
        }

        public void Execute()
        {
            for (int i = 0; i < Consts.BILLION_COUNT; i++)
            {
                ThreadPool.QueueUserWorkItem((c) =>
                {
                    MillionBroker.Trader bk = new MillionBroker.Trader();
                    bk.Buy(DataProvider.GetTrades((i + 1) % 10), 100);

                    Traders.Add(bk);
                });
            }
        }
    }
}
