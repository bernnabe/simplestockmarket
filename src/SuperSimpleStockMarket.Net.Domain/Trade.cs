﻿using SuperSimpleStockMarket.Net.Common.Domain;
using System;

namespace SuperSimpleStockMarket.Net.Domain
{
    public class Trade : DomainBase
    {
        public Stock Stock { get; set; }
        public TradeType TradeType { get; set; }
        public double Price { get; set; }

        public DateTime DateTime { get; set; }
        public int Quantity { get; set; }

        public Trade()
        {
            TradeType = TradeType.BUY;
        }
    }

    public enum TradeType
    {
        BUY,
        SELL,
    }
}
