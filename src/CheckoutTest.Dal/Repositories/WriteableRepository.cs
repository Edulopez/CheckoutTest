using System;
using System.Collections.Generic;
using System.Linq;
using CheckoutTest.Core.Repositories.Abstract;
using CheckoutTest.Core.Entities;
using CheckoutTest.Dal.Context;
namespace CheckoutTest.Dal.Repositories.Concrete
{
    public class WriteableRepository<T> : ReadOnlyRepository<T>, IWriteableRepository<T> where T : Entity
    {
        public WriteableRepository( DbContext<T> dbContext) : base(dbContext) { }

        public void Add(T entity)
        {
            entity.Id = EntitySet.Max(x => x.Value.Id) + 1;
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
