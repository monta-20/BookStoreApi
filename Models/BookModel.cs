using System.Globalization;

namespace BookStoreApi.Models
{
    public class BookModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Descrption { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int TotalPages { get; set; }
        public string Language { get; set; } = string.Empty;
    }
}
