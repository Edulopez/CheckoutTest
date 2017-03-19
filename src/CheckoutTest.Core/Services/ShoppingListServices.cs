using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckoutTest.Core.Entities;
using CheckoutTest.Core.Framework;
using CheckoutTest.Core.Repositories.Abstract;
namespace CheckoutTest.Core.Services
{
    public class ShoppingListServices : BaseService<ShoppingListItem>, IShoppingListService
    {
        IShoppingListItemRepository _ShoppingListRepository;
        public ShoppingListServices(IShoppingListItemRepository shoppingListRepository)
        {
            _ShoppingListRepository = shoppingListRepository;
        }

        public override TaskResult Create(ShoppingListItem entity)
        {
            ValidateOnCreate(entity);
            if(TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _ShoppingListRepository.Add(entity);
                }
                catch (Exception ex)
                {
                    TaskResult.AddErrorMessage("Could not create");
                    TaskResult.Exception = ex;
                }
            }
            return TaskResult;
        }   

        public override TaskResult Delete(int entityId)
        {
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _ShoppingListRepository.Remove(entityId);
                }
                catch (Exception ex)
                {
                    TaskResult.AddErrorMessage("Could not delete");
                    TaskResult.Exception = ex;
                }
            }
            return TaskResult;
        }

        public ShoppingListItem GetItemByName(string itemName)
        {
            if (!TaskResult.ExecutedSuccesfully)
                return null;
            if (string.IsNullOrEmpty(itemName))
                return null;
            if (!TaskResult.ExecutedSuccesfully)
                return null;
            try
            {
                return _ShoppingListRepository.GetByFilter(0, 1, x => x.Title.ToLower() == itemName.ToLower()).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<ShoppingListItem> GetItems()
        {
            if(TaskResult.ExecutedSuccesfully)
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
            return null;
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

        public override TaskResult ValidateOnCreate(ShoppingListItem entity)
        {
            if (entity == null) TaskResult.AddErrorMessage("Not a valid object");
            else if (GetItemByName(entity.Title) != null)
                TaskResult.AddErrorMessage("Title must be unique");

            return TaskResult;
        }

        public override TaskResult ValidateOnDelete(ShoppingListItem entity)
        {
            if (entity == null) TaskResult.AddErrorMessage("Not a valid object");

            return TaskResult;
        }

        public override TaskResult ValidateOnUpdate(ShoppingListItem entity)
        {
            if (entity == null) TaskResult.AddErrorMessage("Not a valid object");

           else  if (GetItemByName(entity.Title) != null)
                TaskResult.AddErrorMessage("Title must be unique");

            return TaskResult;
        }
    }

    public interface IShoppingListService : Framework.IBaseService<ShoppingListItem>
    {
        IEnumerable<ShoppingListItem> GetItems();
        ShoppingListItem GetItemByName(string itemName);
    }

}
