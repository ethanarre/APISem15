using Microsoft.EntityFrameworkCore;


namespace API_sem11.Models
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Product> Products { get; set; } //Nombre de clase y nombre de tabla en db
        public DbSet<Customer> Customers { get; set; } //Nombre de clase y nombre de tabla en db
        public DbSet<Detail> Details { get; set; } //Nombre de clase y nombre de tabla en db
        public DbSet<Invoice> Invoices { get; set; } //Nombre de clase y nombre de tabla en db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAB1507-09\\SQLEXPRESS02; Database=APIsem11; Integrated Security=True;Trust Server Certificate=True ");
        }
    }
}
