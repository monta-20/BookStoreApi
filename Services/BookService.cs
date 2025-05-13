using System.Runtime.CompilerServices;
using BookStoreApi.AppContext;
using BookStoreApi.Contracts;
using BookStoreApi.Models;

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
                Descrption = createBookRequest.Description,
                Category = createBookRequest.Category,
                Language = createBookRequest.Language,
                TotalPages = createBookRequest.TotalPages
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Book added successfully");

            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Descrption,
                Category = book.Category,
                Language = book.Language,
                TotalPages = book.TotalPages

            };

        }
        catch(Exception ex)
        {
            _logger.LogError($"Error adding book : {ex.Message} ");
        }
    }

    public Task<bool> DeleteBookAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<BookResponse> GetBookByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookResponse>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BookResponse> UpdateBookAsync(Guid id, UpdateBookRequest request)
    {
        throw new NotImplementedException();
    }
}
