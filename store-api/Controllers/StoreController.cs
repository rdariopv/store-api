using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using store_api.Services;
using xbiz_store.Models;

namespace store_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : Controller
    {

        private readonly ISalesForce salesForceService;

        public StoreController(ISalesForce arg_salesforce)
        {
            salesForceService = arg_salesforce;
        }

        [Route("products")]
        [HttpGet()]
        public ActionResult<List<ivprd>> listarInventario()
        {
            return salesForceService.listarProductosAlmacen();
        }

        [Route("products/{arg_cod_producto}")]
        [HttpGet()]
        public ActionResult<ivprd> getProduct(int arg_cod_producto)
        {
            return salesForceService.listarProductosAlmacen().First();
        }

    }
}
