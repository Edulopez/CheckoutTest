using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CheckoutTest.Core.Services;
using Microsoft.AspNet.Identity;
using CheckoutTest.Core.Entities;
using System.Net.Http;
using System.Net;

namespace CheckoutTest.Controllers
{
    [RoutePrefix("api/Account")]
    public class ShoppingListController : ApiController
    {
        private readonly IShoppingListService _shoppingListService;
        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

       // [System.Web.Http.HttpGet]
        [HttpPost]
        public HttpResponseMessage Add(string title, int quantity)
        {
            var item = new Core.Entities.ShoppingListItem()
            {
                Title = title,
                Quantity = quantity
            };
            var result = _shoppingListService.Create(item);
            if(result.ExecutedSuccesfully)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item) ;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {Message = result.Message});
            }
        }
    }
}
