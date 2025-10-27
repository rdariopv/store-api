
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbiz_store.Context;
using xbiz_store.Models;

namespace xbiz_store.Repository
{
    public class StoreRepository :IStoreRepository
    {
        private IStoreContext context;
        public StoreRepository(IStoreContext loContext)
        {
            context = loContext;
        }
        public IStoreContext BecoContext => this.context;

        public  List<ivprd> listProductAlmacen()
        {
            try { 
              return  null; 
            }catch (Exception ex) { 
                List<ivprd> lista= new List<ivprd>();

                //ivprd x=new ivprd();
                //x.ivprdcprd = 1;
                //x.ivprddesc ="producto 1";
                //lista.Add(x);
                //ivprd x2 = new ivprd();
                //x2.ivprdcprd = 2;
                //x2.ivprddesc = "producto 2";
                //lista.Add(x2);
                //ivprd x3 = new ivprd();
                //x3.ivprdcprd = 3;
                //x3.ivprddesc = "producto 3";
                //lista.Add(x3);

                //ivprd x4 = new ivprd();
                //x4.ivprdcprd = 4;
                //x4.ivprddesc = "producto 4";
                //lista.Add(x4);

                return lista;
            
            }
          
        }
       

       

     
    }
}
