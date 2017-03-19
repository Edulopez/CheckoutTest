using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using CheckoutTest.Core.Services;
using CheckoutTest.Core.Entities;
using CheckoutTest.Core.Helpers;

namespace CheckoutTest.Controllers
{
    [RoutePrefix("api/ShoppingList")]
    public class ShoppingListController : ApiController
    {
        private readonly IShoppingListItemService _shoppingListService;
        public ShoppingListController(IShoppingListItemService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }
        
        [HttpPost]
        public HttpResponseMessage Add(ShoppingListItem item)
        {
            SanitizerHelper.Paranoide(item);
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

        [HttpGet]
        public HttpResponseMessage GetByName(string title)
        {
            SanitizerHelper.Paranoide(title);
            var result = _shoppingListService.GetItemByName(title);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Not found" });
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var result = _shoppingListService.GetItems();
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Could not get all" });
            }
        }

        [HttpPut]
        public HttpResponseMessage Update(ShoppingListItem item)
        {
            SanitizerHelper.Paranoide(item);
            var result = _shoppingListService.Update(item);
            if (result.ExecutedSuccesfully)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = result.Message });
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var result = _shoppingListService.Delete(id);
            if (result.ExecutedSuccesfully)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = result.Message });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = result.Message });
            }
        }


    }
}
