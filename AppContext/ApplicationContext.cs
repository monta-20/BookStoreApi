using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.AppContext
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<BookModel> Books { get; set; } //DbSet represent table in DB.

        private const string DefaultSchema = "bookapi";
        //Sets all tables under the bookapi schema instead of default public
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(DefaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        /*
         This defines a default schema for your PostgreSQL database:

         In PostgreSQL (and many databases), a schema is like a namespace for tables (e.g., bookapi.Books instead of public.Books).

         By default, PostgreSQL uses the public schema unless you specify otherwise.

         ✅ Why it's important:
         This tells Entity Framework to place all tables into the "bookapi" schema unless otherwise specified.
         */



    }
}
