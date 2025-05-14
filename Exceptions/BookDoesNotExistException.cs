namespace BookStoreApi.Exceptions;

public class BookDoesNotExistException : Exception
{
    private int id { get; set; }

    public BookDoesNotExistException(int id) : base($"Book with ID {id} does not exist.")
    {
        this.id = id;
    }
}
