using Digesett.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Digesett.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
