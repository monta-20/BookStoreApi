using BookStoreApi.AppContext;
using Microsoft.EntityFrameworkCore;
namespace BookStoreApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            if(builder == null) throw new ArgumentNullException(nameof(builder));
            if (builder.Configuration == null ) throw new ArgumentNullException(nameof(builder.Configuration));

            builder.Services.AddDbContext<ApplicationContext>(configure =>
            {
                configure.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")); // UseSqlServer for SQL Server and GetConnectionString("sqlConnection")
            });
        } 
    }
}
