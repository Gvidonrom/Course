using System.Data.Entity;

namespace Course.Models
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
