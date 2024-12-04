using API_sem11.Models;
using API_sem11.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API_sem11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesController2 : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoicesController2(InvoiceContext context)
        {
            _context = context;
        }


        [HttpPost]
        public void Insert([FromBody] InvoiceRequest01 request)
        {
            var Invoice = new Invoice
            {
                CustomerID = request.CustomerID,
                Date = request.Date,
                InvoiceNumber = request.InvoiceNumber,
                Total = request.Total,
            };
            
            _context.Invoices.Add(Invoice);
            _context.SaveChanges();
        }


        [HttpPost]
        public void InsertListInvoiceByCustomer([FromBody] InvoiceRequest02 request)
        {

            foreach (var item in request.InvoiceRequest02_2)
            {
                var invoice = new Invoice
                {
                    CustomerID = request.CustomerID,
                    Date = item.Date,
                    InvoiceNumber = item.InvoiceNumber,
                    Total = item.Total,
                };

                _context.Invoices.Add(invoice);
            };
            _context.SaveChanges();

        }
        
    }
}
