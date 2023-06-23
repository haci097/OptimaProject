using Microsoft.EntityFrameworkCore;
using OptimaProject.Entities.Concrete;

namespace OptimaProject.DbContexts
{
    public class OptimaDbContext : DbContext
    {
        public OptimaDbContext(DbContextOptions<OptimaDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
    }
}
