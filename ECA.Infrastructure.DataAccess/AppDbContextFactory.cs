using ECA.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HAS.Accreditation.Infrastructure.Store.Common
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=DESKTOP-4GKO3R7;Database=Enter.CleanArchitecture;Trusted_Connection=True;TrustServerCertificate=true";
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(connectionString);
            var options = builder.Options;

            return new AppDbContext(options);
        }
    }
}