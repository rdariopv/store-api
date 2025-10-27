using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbiz_store.Models;

namespace xbiz_store.Repository
{
    public  interface IProductRepository
    {
          Task<IEnumerable<Product>> GetAllAsync();
          Task<Product?> GetByIdAsync(int id);
    }
}
