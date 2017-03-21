using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CheckoutTest.Core.Repositories.Abstract;
using CheckoutTest.Core.Entities;

namespace CheckoutTest.Dal.Repositories
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : Entity
    {
        /// <summary>
        /// In memory database
        /// </summary>
        /// @TODO Change this to InMemoryStorage that implements IStorage
        private static Dictionary<int, T> Database { get; set; } = new Dictionary<int, T>();
        
        protected Dictionary<int, T> EntitySet
        {
            get
            {
                if (Database == null)
                    Database = new Dictionary<int, T>();
                return Database;
            }
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
            return this.GetAll().Where(x => x.IsActive ==true).Where(filterBy).Skip(page * count).Take(count);
        }
    }
}
