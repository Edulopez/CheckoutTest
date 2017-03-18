using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTest.Core.Entities
{
    public class ShoppingList:Entity
    {
        public List<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
    }
}
