using Beartic.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureCorsAndControllers();
builder.Services.AddContexts(builder.Configuration);
builder.Services.AddRepositoriesDependencyInjection();
builder.Services.AddServicesDependencyInjection();
builder.AddJwtSecurity();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.AddAppConfig();

app.Run();