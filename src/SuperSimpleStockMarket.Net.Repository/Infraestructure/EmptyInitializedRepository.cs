using SuperSimpleStockMarket.Net.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket.Net.Repository.Infraestructure
{
    public class EmptyInitializedRepository<TDomain> : MemoryRepository<TDomain>
        where TDomain : DomainBase
    {
        protected override void LoadData()
        {
            Initialize();
        }
        public override List<TDomain> Initialize()
        {
            return new List<TDomain>();
        }
    }
}
