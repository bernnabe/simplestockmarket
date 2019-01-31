using SuperSimpleStockMarket.Net.Common.Domain;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Net.Common.Respository
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
