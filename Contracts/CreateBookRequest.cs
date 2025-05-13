namespace BookStoreApi.Contracts;
public record CreateBookRequest
{
    public string Title { get; init; } = string.Empty; 
    public string Author { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string Language { get; init; } = string.Empty;
    public int TotalPages { get; init; }
}
