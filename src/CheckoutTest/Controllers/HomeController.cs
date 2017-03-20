using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckoutTest.Core.Services;
using Checkout.ApiServices.Items;
using Checkout;
namespace CheckoutTest.Controllers
{
    public class HomeController : Controller
    {
        IItemService _itemService;

        public HomeController( IItemService itemService)
        {
            _itemService = itemService;
        }
        public ActionResult Index()
        {
            APIClient Api = new APIClient();


           
            try
            {
                var res = Api.ItemService.CreateItem(new Checkout.ApiServices.Items.RequestModels.CreateItemRequest()
                {
                    Title = "Edu"
                });
            }
            catch (Exception ex) { }
            try
            {
                var res = Api.ItemService.CreateItem(new Checkout.ApiServices.Items.RequestModels.CreateItemRequest()
                {
                    Title = "Miguel"
                });
            }
            catch (Exception ex) { }

          


            var result = Api.ItemService.GetItems();
            
            List<Core.Entities.Item> L = new List<Core.Entities.Item>();
            foreach(var r in result.Model)
            {
                L.Add(new Core.Entities.Item()
                {
                    Id = r.Id,
                    Title = r.Title,
                    Quantity =r.Quantity,
                    IsActive = r.IsActive,
                    CreatedAt = r.CreatedAt
                });

            }
            return View(L);
        }
    }
}
