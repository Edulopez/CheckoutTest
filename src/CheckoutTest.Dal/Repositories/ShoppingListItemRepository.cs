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
    public class ShoppingListItemRepository : WriteableRepository<ShoppingListItem>, IShoppingListItemRepository
    {
        public ShoppingListItemRepository() 
        {
        }
    }
}
