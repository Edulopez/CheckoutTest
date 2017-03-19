using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTest.Core.Repositories.Abstract
{
    public interface IShoppingListItemRepository : IWriteableRepository<Core.Entities.ShoppingListItem>
    {
    }
}
