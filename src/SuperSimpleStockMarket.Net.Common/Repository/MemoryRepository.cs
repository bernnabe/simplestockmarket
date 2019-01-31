using SuperSimpleStockMarket.Net.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStockMarket.Net.Common.Respository
{
    public abstract class MemoryRepository<TDomain> : IRepository<TDomain>
        where TDomain : DomainBase
    {
        protected List<TDomain> Records = new List<TDomain>();

        public MemoryRepository()
        {
            LoadData();
        }

        public virtual void Create(TDomain obj)
        {
            Records.Add(obj);
        }

        public virtual void Delete(TDomain obj)
        {
            Records.Remove(obj);
        }

        public virtual TDomain Get(long id)
        {
            return Records.FirstOrDefault(c => c.Id == id);
        }

        public virtual List<TDomain> GetAll()
        {
            return Records;
        }

        public virtual void Update(TDomain obj)
        {
            TDomain toUpdate = Records.FirstOrDefault(c => c.Id == obj.Id);

            if (toUpdate == null) throw new ArgumentNullException($"Invalid object Id: {obj.Id}");

            Records.Remove(toUpdate);
            Records.Add(obj);
        }

        protected virtual void LoadData()
        {
            List<TDomain> data = Initialize();

            if (data == null || !data.Any()) throw new Exception("Repository has not been initialized!");

            Records.AddRange(Initialize());
        }

        public abstract List<TDomain> Initialize();
    }
}
