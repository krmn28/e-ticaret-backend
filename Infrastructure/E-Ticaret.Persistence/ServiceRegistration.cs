using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Ticaret.Application.Abstractions.Services.Authentications;
using E_Ticaret.Application.Abstractions.Services.AuthServices;
using E_Ticaret.Application.Abstractions.Services.UserServices;
using E_Ticaret.Application.Repositories.Categories;
using E_Ticaret.Application.Repositories.Customers;
using E_Ticaret.Application.Repositories.FileEntities;
using E_Ticaret.Application.Repositories.InvoiceFiles;
using E_Ticaret.Application.Repositories.Orders;
using E_Ticaret.Application.Repositories.ProductImageFiles;
using E_Ticaret.Application.Repositories.Products;
using E_Ticaret.Domain.Entities.Identity;
using E_Ticaret.Persistence.Contexts;
using E_Ticaret.Persistence.Repositories.Categories;
using E_Ticaret.Persistence.Repositories.Customers;
using E_Ticaret.Persistence.Repositories.FileEntities;
using E_Ticaret.Persistence.Repositories.InvoiceFiles;
using E_Ticaret.Persistence.Repositories.Orders;
using E_Ticaret.Persistence.Repositories.ProductImageFiles;
using E_Ticaret.Persistence.Repositories.Products;
using E_Ticaret.Persistence.Services.Auth;
using E_Ticaret.Persistence.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_Ticaret.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
                services.AddDbContext<ETicaretDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

                services.AddIdentity<AppUser, AppRole>(options =>
                {
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                     options.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<ETicaretDbContext>()
                .AddDefaultTokenProviders();


                services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
                services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
                services.AddScoped<IOrderReadRepository, OrderReadRepository>();
                services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
                services.AddScoped<IProductReadRepository, ProductReadRepository>();
                services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
                services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
                services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();


                services.AddScoped<IFileEntityReadRepository, FileEntityReadRepository>();
                services.AddScoped<IFileEntityWriteRepository, FileEntityWriteRepository>();
                services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
                services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
                services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
                services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
                services.AddScoped<IUserService, UserService>();

                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IExternalAuthentication, AuthService>();
                services.AddScoped<IInternalAuthentication, AuthService>();
        }
    }
}