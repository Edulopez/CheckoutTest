using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTest.Core.Repositories.Abstract
{
    public interface IItemRepository : IWriteableRepository<Core.Entities.Item>
    {
    }
}
