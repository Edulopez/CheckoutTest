using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckoutTest.Core.Entities;
using CheckoutTest.Core.Framework;
using CheckoutTest.Core.Repositories.Abstract;
using CheckoutTest.Core.Helpers;
namespace CheckoutTest.Core.Services
{
    /// <summary>
    /// Contains all the logic related to the ShoppingListItems
    /// </summary>
    public class ShoppingListItemService : BaseService<ShoppingListItem>, IShoppingListItemService
    {
        IShoppingListItemRepository _ShoppingListRepository;
        public ShoppingListItemService(IShoppingListItemRepository shoppingListRepository)
        {
            _ShoppingListRepository = shoppingListRepository;
        }


        public override TaskResult ValidateOnCreate(ShoppingListItem entity)
        {
            if (entity == null) TaskResult.AddErrorMessage("Not a valid object");
            else if (GetItemByName(entity.Title) != null)
                TaskResult.AddErrorMessage("Title must be unique");

            return TaskResult;
        }
        public override TaskResult Create(ShoppingListItem entity)
        {
            ValidateOnCreate(entity);
            if(TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _ShoppingListRepository.Add(entity);
                    TaskResult.AddMessage("Entity created");
                }
                catch (Exception ex)
                {
                    TaskResult.AddErrorMessage("Could not create");
                    TaskResult.Exception = ex;
                }
            }
            return TaskResult;
        }

        public ShoppingListItem GetById(int id)
        {
            try
            {
                return _ShoppingListRepository.GetById(id);
            }
            catch (Exception ex)
            {
                TaskResult.AddErrorMessage("Could not get");
                TaskResult.Exception = ex;
                return null;
            }
        }

        public ShoppingListItem GetItemByName(string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
                return null;
            if (!SanitizerHelper.IsClean(itemName))
                return null;
            try
            {
                return _ShoppingListRepository.GetByFilter(0, 1, x => x.Title.ToLower() == itemName.ToLower()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                TaskResult.AddErrorMessage("Could not get");
                TaskResult.Exception = ex;
                return null;
            }
        }

        public IEnumerable<ShoppingListItem> GetItems()
        {
                try
                {
                    return _ShoppingListRepository.GetAll();
                }
                catch (Exception ex)
                {
                    TaskResult.AddErrorMessage("Could not get all");
                    TaskResult.Exception = ex;
                    return null;
                }
        }


        public override TaskResult ValidateOnUpdate(ShoppingListItem entity)
        {
            if (entity == null) TaskResult.AddErrorMessage("Not a valid object");

            else if( GetById(entity.Id) == null)
                TaskResult.AddErrorMessage("Item must exist");

            else if (GetItemByName(entity.Title) != null)
                TaskResult.AddErrorMessage("Title must be unique");

            return TaskResult;
        }
        public override TaskResult Update(ShoppingListItem entity)
        {
            ValidateOnUpdate(entity);
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _ShoppingListRepository.Update(entity);
                    TaskResult.AddMessage("Entity updated");
                }
                catch (Exception ex)
                {
                    TaskResult.AddErrorMessage("Could not update");
                    TaskResult.Exception = ex;
                }
            }
            return TaskResult;
        }

        public override TaskResult ValidateOnDelete(ShoppingListItem entity)
        {
            if (entity == null)
                TaskResult.AddErrorMessage("Not a valid object");

            return TaskResult;
        }
        public override TaskResult Delete(int entityId)
        {
            ValidateOnDelete(GetById(entityId));
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _ShoppingListRepository.Remove(entityId);
                    TaskResult.AddMessage("Entity deleted");
                }
                catch (Exception ex)
                {
                    TaskResult.AddErrorMessage("Could not delete");
                    TaskResult.Exception = ex;
                }
            }
            return TaskResult;
        }

    }

    public interface IShoppingListItemService : Framework.IBaseService<ShoppingListItem>
    {
        IEnumerable<ShoppingListItem> GetItems();
        ShoppingListItem GetItemByName(string itemName);
        ShoppingListItem GetById(int id);
    }

}
