using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTest.Core.Entities
{
    public class ShoppingListItem:TitleEntity
    {
        public int Quantity { get; set; } = 0;
    }
}
