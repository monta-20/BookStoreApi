using BookStoreApi.AppContext;
using BookStoreApi.Exceptions;
using BookStoreApi.Services;
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
            builder.Services.AddScoped<IBookService, BookService>(); // This means that the service will be created once per request and disposed of after the request is complete.
            // This means that the Execptions will be created once per request and disposed of after the request is complete.
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
        } 
    }
}
