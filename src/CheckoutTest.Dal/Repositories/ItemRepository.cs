using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutTest.Core.Entities;
using CheckoutTest.Core.Repositories.Abstract;
using CheckoutTest.Dal.Repositories;

namespace CheckoutTest.Dal.Repositories
{
    public class ItemRepository : WriteableRepository<Item>, IItemRepository
    {
        public ItemRepository() 
        {

        }

        public new void Update(Item entity)
        {
            EntitySet[entity.Id].Title = entity.Title;
            EntitySet[entity.Id].Quantity = entity.Quantity;
        }
    }
}
