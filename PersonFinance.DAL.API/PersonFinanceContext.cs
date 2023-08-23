using Microsoft.EntityFrameworkCore;
using PersonFinance.API.Domain.Entities;
using System.Reflection;

namespace PersonFinance.API.DAL
{
    partial class PersonFinanceContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }

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
