using DataAccess;
using DbHandeller.Db_Access;
using DomainAppServices;
using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainServices;
using HW_23.Basket_Handeller.ServiceB;
using HW_23.Extensions;
using HW_23.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext();
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(@"Server=.\SQLEXPRESS; Initial Catalog = Hw23; Integrated Security = True; Trust Server Certificate=True");
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IOrderAppService, OrderAppService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IOrderItemAppService, OrderItemAppService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();


builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();

builder.Services.AddScoped<ICookieService, CookieService>();

builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();

app.UseMiddleware<LoggingMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();



app.MapGet("/", (context) =>
{
    context.Response.Redirect("/Home/Index");
    return Task.CompletedTask;
});


app.Run();

