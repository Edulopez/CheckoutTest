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
        IShoppingListService _shoppingListService;

        public HomeController( IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
