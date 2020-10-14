using MenagerTasker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MenagerTasker.Core.Data
{
    public sealed class ManagerTaskerContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }


        public ManagerTaskerContext(DbContextOptions<ManagerTaskerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
