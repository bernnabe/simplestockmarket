using SuperSimpleStockMarket.Net.Common.Respository;
using SuperSimpleStockMarket.Net.Domain;

namespace SuperSimpleStockMarket.Net.Repository.Repositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        Stock GetBySymbol(string symbol);
    }
}