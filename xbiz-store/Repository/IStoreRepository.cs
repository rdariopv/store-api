

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbiz_store.Context;
using xbiz_store.Models;

namespace xbiz_store.Repository
{
    public interface IStoreRepository
    {
        IStoreContext BecoContext { get; }
        List<ivprd> listProductAlmacen();
      


    }
}
