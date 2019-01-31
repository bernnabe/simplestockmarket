using SuperSimpleStockMarket.Net.Common.Domain;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Net.Common.Respository
{
    public interface IRepository<TDomain> 
        where TDomain : DomainBase
    {
        TDomain Get(long id);
        void Create(TDomain obj);
        void Update(TDomain obj);
        void Delete(TDomain obj);
        List<TDomain> GetAll();
    }
}
