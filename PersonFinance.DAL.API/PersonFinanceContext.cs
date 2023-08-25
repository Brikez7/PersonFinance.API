using Microsoft.EntityFrameworkCore;
using PersonFinance.API.Domain.Entities;
using System.Reflection;

namespace PersonFinance.API.DAL
{
    public partial class PersonFinanceContext : DbContext
    {
        public const string NameConnection = "PersonFinance";
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Savings> Savings { get; set; }
        public DbSet<MoneyAccount> MoneyAccounts { get; set; }
        public DbSet<Finance> Finances { get; set; }    
        public DbSet<Person> People { get; set; }
        public PersonFinanceContext(DbContextOptions<PersonFinanceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
