using eShop_API.Data;
using eShop_API.Interfaces;
using eShop_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsTelemetry();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<eShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("eShopContext") ?? throw new InvalidOperationException("Connection string 'eShopContext' not found.")));

// Redis Hybrid cache
//builder.Services.AddHybridCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis") ?? throw new InvalidOperationException("Connection string 'Redis' not found.");
    options.InstanceName = "SampleInstance";
});

//Using Redis Cache to implement services for optimizing data services performance
builder.Services.AddScoped<ICartService, CartService>();

//Using Redis Cache to implement services for optimizing data services performance
builder.Services.AddScoped<IProductService, ProductService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<eShopContext>();
    await eShopContextSeed.SeedAsync(context, app.Logger);
    // await DescriptionEmbeddings.GenerateEmbeddingsInRedis(context, app.Logger, builder.Configuration);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
