using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ParamoChallenge.Core.Entities;
using ParamoChallenge.Core.Interfaces;
using ParamoChallenge.Core.Services;
using ParamoChallenge.Infrastructure.Data;
using ParamoChallenge.Infrastructure.Filters;
using ParamoChallenge.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ParamoDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ParamoChallenge"))
    );
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();


builder.Services.AddMvc(options => {
        options.Filters.Add<ValidationFilter>();
    }).AddFluentValidation(options =>
    {
     options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
