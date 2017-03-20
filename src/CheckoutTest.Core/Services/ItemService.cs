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
    public class ItemService : BaseService<Item>, IItemService
    {
        IItemRepository _itemRepository;    
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        public override TaskResult ValidateOnCreate(Item entity)
        {
            if (entity == null) TaskResult.AddErrorMessage("Not a valid object");
            else if (GetItemByName(entity.Title) != null)
                TaskResult.AddErrorMessage("Title must be unique");

            return TaskResult;
        }
        public override TaskResult Create(Item entity)
        {
            ValidateOnCreate(entity);
            if(TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _itemRepository.Add(entity);
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

        public Item GetById(int id)
        {
            try
            {
                return _itemRepository.GetById(id);
            }
            catch (Exception ex)
            {
                TaskResult.AddErrorMessage("Could not get");
                TaskResult.Exception = ex;
                return null;
            }
        }

        public Item GetItemByName(string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
                return null;
            if (!SanitizerHelper.IsClean(itemName))
                return null;
            try
            {
                return _itemRepository.GetByFilter(0, 1, x => x.Title.ToLower() == itemName.ToLower()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                TaskResult.AddErrorMessage("Could not get");
                TaskResult.Exception = ex;
                return null;
            }
        }

        public IEnumerable<Item> GetItems()
        {
                try
                {
                    return _itemRepository.GetAll();
                }
                catch (Exception ex)
                {
                    TaskResult.AddErrorMessage("Could not get all");
                    TaskResult.Exception = ex;
                    return null;
                }
        }


        public override TaskResult ValidateOnUpdate(Item entity)
        {
            if (entity == null) TaskResult.AddErrorMessage("Not a valid object");

            else if( GetById(entity.Id) == null)
                TaskResult.AddErrorMessage("Item must exist");

            else if (GetItemByName(entity.Title) != null)
                TaskResult.AddErrorMessage("Title must be unique");

            return TaskResult;
        }
        public override TaskResult Update(Item entity)
        {
            ValidateOnUpdate(entity);
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _itemRepository.Update(entity);
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

        public override TaskResult ValidateOnDelete(Item entity)
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
                    _itemRepository.Remove(entityId);
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

    public interface IItemService : Framework.IBaseService<Item>
    {
        IEnumerable<Item> GetItems();
        Item GetItemByName(string itemName);
        Item GetById(int id);
    }

}
