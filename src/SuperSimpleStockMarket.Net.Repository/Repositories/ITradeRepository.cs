using System;
using System.Collections.Generic;
using SuperSimpleStockMarket.Net.Common.Respository;
using SuperSimpleStockMarket.Net.Domain;

namespace SuperSimpleStockMarket.Net.Repository.Repositories
{
    public interface ITradeRepository : IRepository<Trade>
    {
        List<Trade> GetLast5MinutesTradesBySymbol(string symbol, DateTime dateRef);
    }
}