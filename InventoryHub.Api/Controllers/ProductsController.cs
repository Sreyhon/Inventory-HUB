using InventoryHub.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "Computer",
                Price = 850,
                Quantity = 10
            },

            new Product
            {
                Id = 2,
                Name = "Keyboard",
                Category = "Accessories",
                Price = 35,
                Quantity = 25
            },

            new Product
            {
                Id = 3,
                Name = "Mouse",
                Category = "Accessories",
                Price = 20,
                Quantity = 40
            }
        };

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(Products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = Products.Count == 0
                ? 1
                : Products.Max(x => x.Id) + 1;

            Products.Add(product);

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.Id },
                product);
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(
            int id,
            Product product)
        {
            var existingProduct =
                Products.FirstOrDefault(x => x.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;

            return NoContent();
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product =
                Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            Products.Remove(product);

            return NoContent();
        }
    }
}