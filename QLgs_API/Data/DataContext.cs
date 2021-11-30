using Microsoft.EntityFrameworkCore;
using QLgs.EdoCta.API.Model;

namespace QLgs.EdoCta.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {}

        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<RegistrationCode> Invitations {get; set;}
    }
}