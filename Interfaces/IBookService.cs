using BookStoreApi.Contracts;

namespace BookStoreApi.Services
{
    public interface IBookService
    {
        Task<BookResponse> AddBookAsync(CreateBookRequest request);
        Task<BookResponse> GetBookByIdAsync(Guid id);
        Task<IEnumerable<BookResponse>> GetBooksAsync(); 

        Task<BookResponse> UpdateBookAsync(Guid id, UpdateBookRequest request);

        Task<bool> DeleteBookAsync(Guid id);
    }
}
