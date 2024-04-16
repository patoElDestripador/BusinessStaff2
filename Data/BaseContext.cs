using Microsoft.EntityFrameworkCore;
using businessStaff2.Models;

namespace businessStaff2.Data
{

    public class BaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CheckInCheckOut> CheckInCheckOuts { get; set; }
        public DbSet<TheViewSitaModel> TheViewSita { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        { }

    }

}

