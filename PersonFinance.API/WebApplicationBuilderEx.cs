using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;
using PersonFinance.API.HostedService;

namespace PersonFinance.API
{
    public static class WebApplicationBuilderEx
    {
        public static void AddRepositores(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<IGenericRepository<Contract>, GenericRepository<Contract>>();
            webApplicationBuilder.Services.AddScoped<IGenericRepository<Expense>, GenericRepository<Expense>>();
            webApplicationBuilder.Services.AddScoped<IGenericRepository<Cash>, GenericRepository<Cash>>();
            webApplicationBuilder.Services.AddScoped<IGenericRepository<Income>, GenericRepository<Income>>();
            webApplicationBuilder.Services.AddScoped<IGenericRepository<InvestAccount>, GenericRepository<InvestAccount>>();
            webApplicationBuilder.Services.AddScoped<IGenericRepository<BankingAccount>, GenericRepository<BankingAccount>>();
        }
        public static void AddPostgresDB(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddDbContext<PersonFinanceContext>(opt => opt.UseNpgsql(
                webApplicationBuilder.Configuration.GetConnectionString(PersonFinanceContext.NameConnection)));
        }
        public static void AddHostedServices(this WebApplicationBuilder webApplicationBuilder)
        {
            //webApplicationBuilder.Services.AddHostedService<DatabaseMigrationHostedService>();
        }
    }
}
