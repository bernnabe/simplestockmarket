using SuperSimpleStockMarket.Net.Common.Respository;
using SuperSimpleStockMarket.Net.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStockMarket.Net.Repository.Repositories
{
    public class TradeRepository : EmptyInitializedRepository<Trade>
    {
        public TradeRepository() : base()
        {
        }

        public List<Trade> GetLast5MinutesTradesBySymbol(string symbol, DateTime dateRef)
        {
            return Records.Where(c => dateRef.AddMinutes(-5) <= c.DateTime
                                        && c.Stock.Symbol == symbol).ToList();
        }
    }
}
