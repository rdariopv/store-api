using Microsoft.AspNetCore.Mvc;
using store_api.Services;
using xbiz_store.DTOs;

namespace store_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService prdService;
        public ProductsController(IProductService productService)
        {
            prdService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await prdService.GetAllProductsAsync();
            
            return Ok(products);
        }
        // ✅ GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await prdService.GetByIdAsync(id);

            if (product == null)
                return NotFound(new { message = $"No se encontró el producto con ID {id}" });

            return Ok(product);
        }

        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var imgProduct = await prdService.GetImageByIdAsync(id);

            if (imgProduct == null)
                return NotFound();

            return File(imgProduct, "image/png");
        }

         [HttpGet("products/{id}/images")]
        public async Task<IActionResult> GetImageByProduct(int id)
        {
            var imgProduct = await prdService.GetListImagesbyIdProductAsync(id);

            if (imgProduct == null)
                return NotFound();

            return Ok(imgProduct);
        }

       
    }
}
