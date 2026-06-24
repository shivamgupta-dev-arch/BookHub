using BookHub.Domain.Common;

namespace BookHub.Domain.Entities;

public class Book : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public Author Author { get; set; } = null!;

    public string ISBN { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string Description { get; set; } = string.Empty;

    public string CoverImageUrl { get; set; } = string.Empty;

    public Category Category { get; set; } = null!;
}