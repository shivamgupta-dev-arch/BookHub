using BookHub.Domain.Common;

namespace BookHub.Domain.Entities;

public class OrderItem : AuditableEntity
{
    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public Guid BookId { get; set; }

    public Book Book { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}