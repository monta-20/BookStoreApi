﻿
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Configurations
{
    public class BookTypeConfigurations : IEntityTypeConfiguration<BookModel>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            // Configure the table name
            builder.ToTable("Books");

            // Configure the primary key
            builder.HasKey(x => x.Id);

            // Configure properties
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Category).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Language).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TotalPages).IsRequired();

            // Seed data
            builder.HasData(
     new BookModel
     {
         Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
         Title = "The Alchemist",
         Author = "Paulo Coelho",
         Description = "The Alchemist follows the journey of an Andalusian shepherd",
         Category = "Fiction",
         Language = "English",
         TotalPages = 208
     },
     new BookModel
     {
         Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
         Title = "To Kill a Mockingbird",
         Author = "Harper Lee",
         Description = "A novel about the serious issues of rape and racial inequality.",
         Category = "Fiction",
         Language = "English",
         TotalPages = 281
     },
     new BookModel
     {
         Id = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
         Title = "1984",
         Author = "George Orwell",
         Description = "A dystopian social science fiction novel and cautionary tale about the dangers of totalitarianism.",
         Category = "Fiction",
         Language = "English",
         TotalPages = 328
     }
 );

        }
    }
}