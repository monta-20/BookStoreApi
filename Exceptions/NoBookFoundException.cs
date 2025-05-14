namespace BookStoreApi.Exceptions;

public class NoBookFoundException : Exception
{
    public int Id { get; }

    public NoBookFoundException(int id)
        : base($"No book found with ID {id}.")
    {
        Id = id;
    }
}
