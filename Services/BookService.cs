using System.Runtime.CompilerServices;
using BookStoreApi.AppContext;
using BookStoreApi.Contracts;

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
    public Task<BookResponse> AddBookAsync(CreateBookRequest request)
    {
        throw new NotImplementedException();
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
