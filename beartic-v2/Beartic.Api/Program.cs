using Beartic.Api.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddContexts(builder.Configuration);
builder.Services.AddRepositoriesDependencyInjection();
builder.Services.AddServicesDependencyInjection();
builder.AddJwtSecurity(builder.Configuration["dn3923nfc9w0hc92h90p2wh"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddAppConfig(); 

app.Run();