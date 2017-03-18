using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CheckoutTest.Core.Repositories.Abstract;
using CheckoutTest.Core.Entities;
using CheckoutTest.Dal.Context;

namespace CheckoutTest.Dal.Repositories.Concrete
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : Entity
    {
        protected DbContext<T> _context;
        protected Dictionary<int, T> EntitySet;
        public ReadOnlyRepository( DbContext<T> dbcontext)
        {
            _context = dbcontext;
            EntitySet = dbcontext.Database;
        }
    
        public IEnumerable<T> GetAll()
        {
            var r = EntitySet.Where(x => x.Value.IsActive);
            return r.Select( x => x.Value);
        }
        public int Count()
        {
            return EntitySet.Count(x => x.Value.IsActive == true);
        }
      
        public T GetById(int id)
        {
            return EntitySet.FirstOrDefault(x => x.Value.Id == id && x.Value.IsActive).Value;
        }

        public IEnumerable<T> GetLatests(int number)
        {
            var r = EntitySet.Where(x => x.Value.IsActive).Take(number).ToList();
            return r.Select(x => x.Value);
        }

        public IEnumerable<T> GetByFilter(int page, int count, Func<T, bool> filterBy)
        {
            return this.GetAll().Where(x => x.IsActive).Where(filterBy).Skip(page * count).Take(count);
        }
    }
}
