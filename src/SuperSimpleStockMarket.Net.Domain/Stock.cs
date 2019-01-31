using SuperSimpleStockMarket.Net.Common.Domain;
using System;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Net.Domain
{
    public class Stock : DomainBase
    {
        public string Symbol { get; set; }
        public string Type { get; set; }

        private int _lastDividend;
        public int LastDividend
        {
            get
            {
                return _lastDividend;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("LastDividend must be grather than zero");
                else _lastDividend = value;
            }
        }

        private int _fixedDividend;
        public int FixedDividend
        {
            get
            {
                return _fixedDividend;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("FixedDividend must be grather than zero");
                else _fixedDividend = value;
            }
        }
        public int ParValue { get; set; }
        public IList<Trade> Trades { get; set; }

        public Stock()
        {
            Trades = new List<Trade>();
        }

        public void AddTrade(Trade trade)
        {
            Trades.Add(trade);
        }
    }
}
