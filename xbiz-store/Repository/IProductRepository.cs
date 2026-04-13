using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbiz_store.DTOs;
using xbiz_store.Queries;

namespace xbiz_store.Repository
{
    public  interface IProductRepository
    {
          Task<IEnumerable<ProductQuery>> GetAllAsync();
          Task<ProductQuery?> GetByIdAsync(int id);
           Task<byte[]> GetImageByIdAsync(int id);
    }
}
