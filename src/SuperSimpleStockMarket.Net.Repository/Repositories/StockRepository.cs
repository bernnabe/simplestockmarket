using SuperSimpleStockMarket.Net.Common.Respository;
using SuperSimpleStockMarket.Net.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStockMarket.Net.Repository.Repositories
{
    public class StockRepository : MemoryRepository<Stock>
    {
        public Stock GetBySymbol(string symbol)
        {
            return Records.FirstOrDefault(c => c.Symbol == symbol);
        }

        public override List<Stock> Initialize()
        {
            return new List<Stock>
            {
                new Stock { Id = 1, Symbol = "TEA", Type = "COMMON", LastDividend = 0, FixedDividend = 0, ParValue = 100 },
                new Stock { Id = 2, Symbol = "POP", Type = "COMMON" ,LastDividend = 8, FixedDividend = 0, ParValue = 100 },
                new Stock { Id = 3, Symbol = "ALE", Type = "COMMON" ,LastDividend = 23, FixedDividend = 0, ParValue = 60},
                new Stock { Id = 4, Symbol = "GIN", Type = "PREFERRED" ,LastDividend = 8, FixedDividend = 2, ParValue = 100 },
                new Stock { Id = 5, Symbol = "JOE", Type = "COMMON",LastDividend = 13, FixedDividend = 0, ParValue = 250 },
            };
        }
    }
}
