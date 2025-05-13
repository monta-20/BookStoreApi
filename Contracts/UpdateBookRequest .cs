namespace BookStoreApi.Contracts;
public record UpdateBookRequest
{
    public string Title { get; set; } = string.Empty; 
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public int TotalPages { get; set; }

}

/* 
✅ Why Use record and init in This Case?
1. 🔐 Immutability for Safety
You're creating a DTO (Data Transfer Object) — it should not be modified after it's created. Using init makes each property settable only at creation, helping prevent accidental mutations.
2. 🧱 Value-Based Equality with record
When you define a record, two instances with the same data are considered equal, unlike class where equality is based on reference by default.
3. 🧼 Cleaner Syntax
You get automatic implementations for:

ToString() → for better logging/debugging

Equals() and GetHashCode() → for comparisons and collections

Optional: use of with expressions for shallow copy
*/
