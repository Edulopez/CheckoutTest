using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckoutTest.Core.Services;

namespace CheckoutTest.Controllers
{
    public class HomeController : Controller
    {
        IShoppingListItemService _shoppingListService;

        public HomeController( IShoppingListItemService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
