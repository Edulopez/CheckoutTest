using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.ApiServices.RecurringPayments.ResponseModels;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Items.RequestModels;
using Checkout.ApiServices.Items.ResponseModels;

namespace Checkout.ApiServices.Items
{
    public class ItemService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<Item> CreateItem( CreateItemRequest requestModel)
        {
            return new ApiHttpClient().PostRequest<Item>(ApiUrls.Item, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<List<Item>> GetItems()
        {
            return new ApiHttpClient().GetRequest<List<Item>>(ApiUrls.Item, AppSettings.SecretKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<Item> GetItemByTitle(string title)
        {
            return new ApiHttpClient().GetRequest<Item>(string.Format(ApiUrls.Items, title), AppSettings.SecretKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<OkResponse> UpdateItem(UpdateItemRequest requestModel)
        {
            return new ApiHttpClient().PutRequest<OkResponse>(ApiUrls.Item, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<OkResponse> DeleteItem(int id)
        {
            return new ApiHttpClient().DeleteRequest<OkResponse>(string.Format(ApiUrls.Items, id), AppSettings.SecretKey);
        }


    }
}
