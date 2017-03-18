using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutTest.Core.Entities;
namespace CheckoutTest.Core.Services
{
    public class ShoppingListServices : IShoppingListServices
    {
        public ShoppingListServices()
        {

        }

        public ShoppingListItem AddItem(ShoppingListItem item)
        {
            throw new NotImplementedException();
        }

        public ShoppingListItem GetItemByName(string itemName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingListItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string itemName)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(ShoppingListItem item)
        {
            throw new NotImplementedException();
        }

        public ShoppingListItem UpdateItem(ShoppingListItem item)
        {
            throw new NotImplementedException();
        }
    }

    public interface IShoppingListServices
    {
        ShoppingListItem AddItem(ShoppingListItem item);
        void RemoveItem(ShoppingListItem item);
        void RemoveItem(string itemName);
        ShoppingListItem UpdateItem(ShoppingListItem item);
        IEnumerable<ShoppingListItem> GetItems();
        ShoppingListItem GetItemByName(string itemName);
    }

}
