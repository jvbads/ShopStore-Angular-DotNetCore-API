using Microsoft.EntityFrameworkCore;
using ShopStore.Application.Interfaces;
using ShopStore.Application.Services;
using ShopStore.Repository;
using ShopStore.Repository.Context;
using ShopStore.Repository.Interfaces;

var appOrigins = "_appOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")); });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IGeralRepository, GeralRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddCors(options => options.AddPolicy(name: appOrigins,
                         policy => { policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(appOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
