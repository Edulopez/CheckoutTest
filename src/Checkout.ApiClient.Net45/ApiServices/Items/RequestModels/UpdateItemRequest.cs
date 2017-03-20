using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Items.RequestModels
{
    public class UpdateItemRequest
    {
        public int id { get; set; }
        public string Title { get; set; }
    }
}
