using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication2.Entitties;

namespace WebApplication2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Superman> Supermans { get; set; }
    }
}
