using BookHub.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using BookHub.Application.Interfaces;
using BookHub.Persistence.Repositories;
using MediatR;
using FluentValidation;
using BookHub.Application.Behaviors;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(
typeof(IRepository<>),
typeof(GenericRepository<>));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
    typeof(BookHub.Application.Features.Auth.Commands.Register.RegisterCommand)
    .Assembly);
});

builder.Services.AddValidatorsFromAssembly(
typeof(BookHub.Application.Features.Auth.Commands.Register.RegisterCommandValidator)
.Assembly);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();