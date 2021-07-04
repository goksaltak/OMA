using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class OmaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OMADB;Trusted_connection=true");
        }
        public DbSet<Tb_Product> tb_Product { get; set; }
        public DbSet<Tb_Customer> tb_Customer { get; set; }
        public DbSet<Tb_Order> tb_Order { get; set; }
        public DbSet<Tb_OrderDetail> tb_OrderDetail { get; set; }
    }
}
