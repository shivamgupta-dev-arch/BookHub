using BookHub.Application.Behaviors;
using BookHub.Application.Interfaces;
using BookHub.Infrastructure.Services;
using BookHub.Persistence.Context;
using BookHub.Persistence.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository and Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(
    typeof(IRepository<>),
    typeof(GenericRepository<>));

// Password Hashing
builder.Services.AddScoped<
    IPasswordHasherService,
    PasswordHasherService>();

// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(BookHub.Application.Features.Auth.Commands.Register.RegisterCommand)
            .Assembly);
});

// FluentValidation
builder.Services.AddValidatorsFromAssembly(
    typeof(BookHub.Application.Features.Auth.Commands.Register.RegisterCommandValidator)
        .Assembly);

// Validation Pipeline
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

var app = builder.Build();

// HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();