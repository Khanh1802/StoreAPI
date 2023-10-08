using API.Data;
using API.Entities;
using API.Extesions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly StoreContext _context;

        public ProductController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] ProductParams productParams)
        {
            var query = _context.Products
                .Sort(productParams.OrderBy)
                .Search(productParams.Search)
                .Filter(productParams.Brands, productParams.Types)
                .AsQueryable();
            var products = await PageList<Product>.ToPageListAsync
                (query, productParams.PageNumber, productParams.PageSize);
            Response.Headers.Add("Pagination", JsonSerializer.Serialize(products.MetaData));
            return products.Data;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var brands = await _context.Products.Select(x => x.Brand).Distinct().ToListAsync();
            var types = await _context.Products.Select(x => x.Type).Distinct().ToListAsync();
            return Ok(new { brands, types });
        }
    }
}
