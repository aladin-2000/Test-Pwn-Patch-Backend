using Microsoft.EntityFrameworkCore;
using test_Pwn_Pach.Models;

namespace test_Pwn_Pach.Data
{
    public class UsersDbContexte : DbContext
    {
        public UsersDbContexte(DbContextOptions options) : base(options)
        {
        }

        //dbset
        public DbSet<User> Users { get; set; }

    }
}
