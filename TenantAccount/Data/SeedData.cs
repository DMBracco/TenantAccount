using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TenantAccount.Data;
using TenantAccount.Data.Entities;

namespace TenantAccount.Data
{

    public static class SeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.СontractStatuses.Any()) {
                context.СontractStatuses.AddRange(
                    new СontractStatus
                    {
                        Name = "На расмотрении"
                    }
                );
            }


            context.SaveChanges();
        }
    }
}
