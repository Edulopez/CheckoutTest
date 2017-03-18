using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutTest.Core.Entities;
namespace CheckoutTest.Dal.Context
{
    /// <summary>
    /// In memory database
    /// </summary>
    public class DbContext<T> where T: Entity
    {
        private static DbContext<T> _context;
        
        public static DbContext<T> Context
        {
            get
            {
                if (_context == null)
                    _context = new DbContext<T>();

                return _context;
            }
        }

        public Dictionary<int, T> Database { get; set; } = new Dictionary<int, T>();
        private DbContext() { }


    }
}
