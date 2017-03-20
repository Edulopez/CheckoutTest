using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Items.ResponseModels
{
    public class Item
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
