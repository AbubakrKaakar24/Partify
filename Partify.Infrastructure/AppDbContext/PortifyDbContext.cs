using Microsoft.EntityFrameworkCore;
using Partify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partify.Infrastructure.AppDbContext
{
    public class PortifyDbContext:DbContext
    {
        public PortifyDbContext(DbContextOptions<PortifyDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
