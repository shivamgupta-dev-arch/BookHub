using BookHub.Domain.Common;

namespace BookHub.Domain.Entities;

public class Author : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Biography { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}