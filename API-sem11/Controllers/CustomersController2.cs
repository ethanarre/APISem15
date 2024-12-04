using API_sem11.Models;
using API_sem11.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API_sem11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController2: ControllerBase
    {
        private readonly InvoiceContext _context;

        public CustomersController2(InvoiceContext context)
        {
            _context = context;
        }


        [HttpPost]
        public void Insert([FromBody] CustomerRequest01 request)
        {
            var Customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DocumentNumber = request.DocumentNumber
            };

            _context.Customers.Add(Customer);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Delete([FromBody] CustomerRequest02 request)
        {
            var Customer = _context.Customers.Find(request.CustomerID);
            Customer.IsDeleted = true;
            _context.SaveChanges();

        }

        [HttpPut]
        public void Update([FromBody] CustomerRequest03 request)
        {
            var customer = _context.Customers.Find(request.CustomerID, request.Email);
            customer.DocumentNumber = request.DocumentNumber;
            _context.SaveChanges();
            
        }
    }
}
