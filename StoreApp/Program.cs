using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using StoreApp.Dtos.Category;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    var jsonInputFormatter = options.InputFormatters
        .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
        .Single();
    jsonInputFormatter.SupportedMediaTypes.Add("application/csp-report");
}
  )
    .AddNewtonsoftJson(x=> x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddFluentValidation(x=> x.RegisterValidatorsFromAssemblyContaining<CategoryPostDto>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));



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
