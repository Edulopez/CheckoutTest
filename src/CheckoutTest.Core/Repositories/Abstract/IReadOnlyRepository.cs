using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CheckoutTest.Core.Repositories.Abstract
{
    public interface IReadOnlyRepository<T> where T:class
    {
        int Count();
        T GetById(int id);
        IEnumerable<T> GetLatests(int number);
        IEnumerable<T> GetByFilter(int page, int count, Func<T, bool> filterBy);
    }
}
