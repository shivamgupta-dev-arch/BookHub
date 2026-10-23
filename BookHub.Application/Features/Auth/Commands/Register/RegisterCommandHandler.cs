using BookHub.Application.Interfaces;
using BookHub.Domain.Entities;
using MediatR;

namespace BookHub.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasherService _passwordHasher;

    public RegisterCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasherService passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<int> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            RoleId = 2,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = "System"
        };

        await _unitOfWork.Users.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }
}