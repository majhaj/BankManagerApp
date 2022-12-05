using BankManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using BankManager.Services.Interfaces.Interfaces;
using BankManager.Services;
using BankManager.Services.Interfaces;
using BankManager.Services.Services;

namespace BankManager.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IBankManagerContext, BankManagerContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<IAccountTransactionService, AccountTransactionService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApprovementService, ApprovementService>();

            services.AddScoped<ITaxService, UeTaxService>();

            return services;
        }
    }

    public static class MyStaticClass
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
