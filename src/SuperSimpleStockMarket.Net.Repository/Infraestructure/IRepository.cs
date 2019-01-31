using SuperSimpleStockMarket.Net.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket.Net.Repository.Infraestructure
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
