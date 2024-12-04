using API_sem11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using API_sem11.Requests;

namespace API_sem11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController2: ControllerBase
    {
        private readonly InvoiceContext _context;

        public ProductsController2(InvoiceContext context)
        {
            _context = context;
        }


        [HttpPost]
        public void Insert([FromBody] ProductRequest01 request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                IsDeleted = false
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Delete([FromBody] ProductRequest02 request)
        {
            var product = _context.Products.Find(request.ProductID);
            product.IsDeleted = true;
            _context.SaveChanges();

        }

        [HttpPut]
        public void Update([FromBody] ProductRequest03 request)
        {
            var product = _context.Products.Find(request.ProductID);
            product.Price = request.Price;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteListProduct([FromBody] ProductRequest04 request)
        {
            foreach(var product in request.productRequest02s)
            {
                var producto = _context.Products.Find(product.ProductID);
                producto.IsDeleted = true;
                _context.SaveChanges();
            }
        }


    }
}
