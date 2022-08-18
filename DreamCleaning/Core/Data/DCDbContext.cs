using DC.WebApi.Api;
using DC.WebApi.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DC.WebApi.Core.Data
{
    public class DCDbContext : DbContext
    {
        private readonly IPasswordHelper _password;

        public DCDbContext(DbContextOptions options, IPasswordHelper passwordHelper) : base(options)
        {
            _password = passwordHelper;
        }


        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .Property(x => x.Role)
                .HasConversion<string>();

            var salt = _password.GenerateSalt();
            var pwd = _password.GenerateHash("admin", salt);

            modelBuilder.Entity<UserEntity>()
                .HasData(new UserEntity("admin", pwd, salt, UserRole.SuperAdmin)
                {
                    Id = 1
                });
        }
    }

    
    
}
