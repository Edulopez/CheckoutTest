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
    //[Authorize]
    [RoutePrefix("Carts/items")]
    public class ItemController : ApiController
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        ///  Add a new item to the Cart
        /// </summary>
        /// Post Carts/Item/
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Add(Item item)
        {
            SanitizerHelper.Paranoide(item);
            var result = _itemService.Create(item);
            if(result.ExecutedSuccesfully)
            {
                return Request.CreateResponse(HttpStatusCode.Created, item) ;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {Message = result.Message});
            }
        }

        /// <summary>
        ///  Get an item by its title from the Cart
        /// </summary>
        /// Get Carts/Item/{title:string}
        [Route("{title}")]
        [HttpGet]
        public HttpResponseMessage Get(string title)
        {
            SanitizerHelper.Paranoide(title);
            var result = _itemService.GetItemByName(title);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Not found" });
            }
        }

        /// <summary>
        ///  Get all items from the Cart
        /// </summary>
        /// Get Carts/Item/
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var result = _itemService.GetItems();
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Could not get all" });
            }
        }

        /// <summary>
        ///  Get all items paginated from the Cart
        /// </summary>
        /// Get Carts/Item/
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get(int pageNumber, int count= 20)
        {
            var result = _itemService.GetItems(pageNumber, count);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Could not get all" });
            }
        }

        /// <summary>
        ///  Update an item from the Cart
        /// </summary>
        /// PUT Carts/Item/
        [Route("")]
        [HttpPut]
        public HttpResponseMessage Update(Item item)
        {
            SanitizerHelper.Paranoide(item);
            var result = _itemService.Update(item);
            if (result.ExecutedSuccesfully)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = result.Message });
            }
        }

        /// <summary>
        ///  Delete an item from the Cart
        /// </summary>
        /// Delete Carts/Item/{id}
        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var result = _itemService.Delete(id);
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
