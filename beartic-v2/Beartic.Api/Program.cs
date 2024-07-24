using Beartic.Infraestructure.AuthContext.DataContext;
using Beartic.Infraestructure.BussinessContext.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opts => opts.UseSqlServer("", b => b.MigrationsAssembly("Beartic.Api")));
builder.Services.AddDbContext<AuthContext>(opts => opts.UseSqlServer("", b => b.MigrationsAssembly("Beartic.Api")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
