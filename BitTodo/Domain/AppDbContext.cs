using BitTodo.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitTodo.Domain
{
    public class AppDbContext: IdentityDbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public AppDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
