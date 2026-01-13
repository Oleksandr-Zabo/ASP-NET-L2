using ASP_NET_L2.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace ASP_NET_L2.DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}
