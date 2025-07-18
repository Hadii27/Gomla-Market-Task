using GomlaMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace GomlaMarket.db
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options) : base(options)
        {
        }
        public DbSet<SaleRecord> saleRecords { get; set; }
        public DbSet<PurchaseRecord> purchaseRecords { get; set; }

    }
}
