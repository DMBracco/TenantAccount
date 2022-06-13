using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TenantAccount.Data.Entities;

namespace TenantAccount.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles => Set<Profile>();
        //public DbSet<Tenant> Tenants => Set<Tenant>();
        //public DbSet<TenantStatus> TenantStatuses => Set<TenantStatus>();
        public DbSet<Сontract> Сontracts => Set<Сontract>();
        public DbSet<СontractStatus> СontractStatuses => Set<СontractStatus>();
        public DbSet<Message> Messages => Set<Message>();
    }
}