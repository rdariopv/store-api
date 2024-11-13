using xbiz_store.Models;
using xbiz_store.Repository;

namespace store_api.Services
{
    public class SalesForce : ISalesForce
    {
        private readonly IStoreRepository repository;

        public SalesForce(IStoreRepository arg_repository)
        {
            this.repository = arg_repository;
        }

        public List<ivprd> listarProductosAlmacen()
        {
           return this.repository.listProductAlmacen();
        }
    }
}
