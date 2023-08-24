using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL;

namespace PersonFinance.API
{
    public class DatabaseMigrationHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DatabaseMigrationHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var appDbContext = scope.ServiceProvider.GetRequiredService<PersonFinanceContext>();

            if (!await appDbContext.Database.CanConnectAsync(cancellationToken) || (await appDbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
            {
                await appDbContext.Database.MigrateAsync(cancellationToken);
                return;
            }

            return;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
