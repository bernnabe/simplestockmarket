using System;
using System.Collections.Generic;
using System.Linq;
using SuperSimpleStockMarket.Net.Domain;
using SuperSimpleStockMarket.Net.Repository.Infraestructure;

namespace SuperSimpleStockMarket.Net.Repository.Repositories
{
    public class TradeRepository : EmptyInitializedRepository<Trade>
    {
        public List<Trade> GetLast5MinutesTradesBySymbol(string symbol, DateTime dateRef)
        {
            return Records.Where(c => dateRef.AddMinutes(-5) <= c.DateTime).ToList();
        }
    }
}
