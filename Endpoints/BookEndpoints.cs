using BookStoreApi.Contracts;
using BookStoreApi.Services;

namespace BookStoreApi.Endpoints;

public static  class BookEndpoints
{
	public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
	{
        app.MapPost("/books", async (CreateBookRequest createBookRequest, IBookService bookService) =>
        {
            var book = await bookService.AddBookAsync(createBookRequest);
            return Results.Created($"/books/{book.Id}", book);
        });
        app.MapGet("/books", async(IBookService bookService) =>
        {
            var books = await bookService.GetBooksAsync();
            return Results.Ok(books);
        });
        app.MapGet("/books/{id:guid}" , async(Guid id , IBookService bookService) =>
        {
            var book = await bookService.GetBookByIdAsync(id);
            return book is not null ? Results.Ok(book) : Results.NotFound();
        });
        app.MapPut("/books/{id:guid}",async(Guid id , UpdateBookRequest updateBookRequest, IBookService bookService) =>
        {
            var book = await bookService.UpdateBookAsync(id, updateBookRequest);
            return book is not null ? Results.Ok(book) : Results.NotFound();
        });
        app.MapDelete("/books/{id:guid}" , async(Guid id , IBookService bookService) =>
        {
            var deleted = await bookService.DeleteBookAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
        return app; 

    }
}
