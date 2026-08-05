using BookHub.Application.Interfaces;
using BookHub.Domain.Entities;
using BookHub.Persistence.Context;

namespace BookHub.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Books = new GenericRepository<Book>(_context);
        Categories = new GenericRepository<Category>(_context);
        Users = new GenericRepository<User>(_context);
        Orders = new GenericRepository<Order>(_context);
    }

    public IRepository<Book> Books { get; }

    public IRepository<Category> Categories { get; }

    public IRepository<User> Users { get; }

    public IRepository<Order> Orders { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}