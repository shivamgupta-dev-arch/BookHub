using BookHub.Domain.Common;

namespace BookHub.Domain.Entities;

public class Order : AuditableEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public string ShippingAddress { get; set; } = string.Empty;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}