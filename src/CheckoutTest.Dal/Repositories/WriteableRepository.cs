using System;
using System.Collections.Generic;
using System.Linq;
using CheckoutTest.Core.Repositories.Abstract;
using CheckoutTest.Core.Entities;
namespace CheckoutTest.Dal.Repositories
{
    public class WriteableRepository<T> : ReadOnlyRepository<T>, IWriteableRepository<T> where T : Entity
    {
        public WriteableRepository() : base() { }

        public void Add(T entity)
        {
            if (EntitySet.Count > 0)
                entity.Id = EntitySet.Max(x => x.Value.Id) + 1;
            else
                entity.Id = 1;
            EntitySet.Add(entity.Id,entity);
        }
        public void Update(T entity)
        {
            var e = EntitySet[entity.Id] = entity;
        }
        public void Remove(int id)
        {
            Remove(EntitySet[id]);
        }
        public void Remove(T entity)
        {
            entity.IsActive = false;
        }
    }
}
