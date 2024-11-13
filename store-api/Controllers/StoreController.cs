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

        [Route("product/listarInventario")]
        [HttpPost()]
        public ActionResult<List<ivprd>> listarInventario()
        {
            return salesForceService.listarProductosAlmacen();
        }

    }
}
