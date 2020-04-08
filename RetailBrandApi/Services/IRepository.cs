using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetailBrandApi.Models;

namespace RetailBrandApi.Services
{
    public abstract class RetailBrandType<T>
    {
        public abstract List<T> Get();

        public abstract T Get(int SkuNumber);

        public abstract T Create(T entity);

        public abstract void Update(T entity);

        public abstract void Remove(T entity);

        public abstract void Remove(int Id);

    }
}
