﻿using System.Runtime.CompilerServices;
using BookStoreApi.AppContext;
using BookStoreApi.Contracts;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Services;
public class BookService : IBookService
{
    private readonly ApplicationContext _context;
    private readonly ILogger<BookService> _logger;
    public BookService (ApplicationContext context, ILogger<BookService> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<BookResponse> AddBookAsync(CreateBookRequest createBookRequest)
    {
        try
        {
            var book = new BookModel
            {
                Title = createBookRequest.Title,
                Author = createBookRequest.Author,
                Description = createBookRequest.Description,
                Category = createBookRequest.Category,
                Language = createBookRequest.Language,
                TotalPages = createBookRequest.TotalPages
            };

            // Add the book to the database
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Book added successfully.");

            // Return the details of the created book
            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                Language = book.Language,
                TotalPages = book.TotalPages
            };
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding book: {ex.Message}");
            throw;
        }
    }
    public async Task<bool> DeleteBookAsync(Guid id)
    {
        try
        {
            var book = await _context.Books.FindAsync(id);
            if(book == null)
            {
                _logger.LogWarning($"Book with ID {id} not found.");
                return false;
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            _logger.LogInformation($"Book with ID {id} deleted successfully.");
            return true;
        }
        catch(Exception ex)
        {
            _logger.LogError($"Error deleting book: {ex.Message}");
            throw;
        }
    }

    public async Task<BookResponse> GetBookByIdAsync(Guid id)
    {
        try
        {
            // Find the book by its ID
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                _logger.LogWarning($"Book with ID {id} not found.");
                return null;
            }

            // Return the details of the book
            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                Language = book.Language,
                TotalPages = book.TotalPages
            };
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving book: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<BookResponse>> GetBooksAsync()
    {
        try
        {
            var books = await _context.Books.ToListAsync();
            return books.Select(book => new BookResponse
            {
                Id = book.Id , 
                Title = book.Title ,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                Language = book.Language,
                TotalPages = book.TotalPages
            });

        }
        catch(Exception ex )
        {
            _logger.LogError($"Error retrieving books: {ex.Message}");
            throw; 
        }
    }

    public async Task<BookResponse> UpdateBookAsync(Guid id, UpdateBookRequest book)
    {
        try
        {
            var existingBook = await _context.Books.FindAsync(id);
            if(existingBook == null)
            {
                _logger.LogWarning($"Book with ID {id} not found.");
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            existingBook.Category = book.Category;
            existingBook.Language = book.Language;
            existingBook.TotalPages = book.TotalPages;

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Book with ID {id} updated successfully.");
            return new BookResponse
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                Author = existingBook.Author,
                Description = existingBook.Description,
                Category = existingBook.Category,
                Language = existingBook.Language,
                TotalPages = existingBook.TotalPages
            };


        }
        catch(Exception ex)
        {
            _logger.LogError($"Error updating book: {ex.Message}");
            throw;
        }
    }
}
