using BookHub.Domain.Entities;

namespace BookHub.Application.Interfaces;

public interface IUnitOfWork
{
    IRepository<Book> Books { get; }

    IRepository<Category> Categories { get; }

    IRepository<User> Users { get; }

    IRepository<Order> Orders { get; }

    Task<int> SaveChangesAsync();
}