using Microsoft.EntityFrameworkCore;
using DatadogCrud.Api.Models;

namespace DatadogCrud.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Item> Items { get; set; }
    }
}