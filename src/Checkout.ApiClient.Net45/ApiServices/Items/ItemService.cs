using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.ApiServices.RecurringPayments.ResponseModels;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Items.RequestModels;
using Checkout.ApiServices.Items.ResponseModels;
using Checkout.Utilities;

namespace Checkout.ApiServices.Items
{
    public class ItemService
    {
        /// <summary>
        /// Create a new item
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<Item> CreateItem( CreateItemRequest requestModel)
        {
            return new ApiHttpClient().PostRequest<Item>(ApiUrls.Item, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Get all the items
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<List<Item>> GetItems()
        {
            return new ApiHttpClient().GetRequest<List<Item>>(ApiUrls.Item, AppSettings.SecretKey);
        }

        /// <summary>
        /// Get items paginated
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<List<Item>> GetItems(GetItemListRequest requestModel)
        {
            var getItemsListUri = ApiUrls.Item;

            if (requestModel.Count.HasValue)
            {
                getItemsListUri = UrlHelper.AddParameterToUrl(getItemsListUri, "count", requestModel.Count.ToString());
            }
            int pageNumber;
            if (int.TryParse(requestModel.PageNumber, out pageNumber))
            {
                int x = 0;
                getItemsListUri = UrlHelper.AddParameterToUrl(getItemsListUri, "pageNumber", requestModel.PageNumber);
            }
            return new ApiHttpClient().GetRequest<List<Item>>(getItemsListUri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Get an item by Title
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<Item> GetItemByTitle(string title)
        {
            return new ApiHttpClient().GetRequest<Item>(string.Format(ApiUrls.Items, title), AppSettings.SecretKey);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<OkResponse> UpdateItem(UpdateItemRequest requestModel)
        {
            return new ApiHttpClient().PutRequest<OkResponse>(ApiUrls.Item, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<OkResponse> DeleteItem(int id)
        {
            return new ApiHttpClient().DeleteRequest<OkResponse>(string.Format(ApiUrls.Items, id), AppSettings.SecretKey);
        }


    }
}
