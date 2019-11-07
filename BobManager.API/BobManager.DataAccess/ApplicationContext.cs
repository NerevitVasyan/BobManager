using BobManager.DataAccess.Configuration;
using BobManager.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BobManager.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
        }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupRole> GroupRoles { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<SpendingCategory> SpendingCategories { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }
        public DbSet<UsersGroup> UsersGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersGroup>()
                .HasKey(t => new { t.UserId, t.GroupId, t.GroupRoleId });

            modelBuilder.Entity<UsersGroup>()
                .HasOne(sc => sc.Group)
                .WithMany(s => s.Users)
                .HasForeignKey(sc => sc.GroupId);

            modelBuilder.Entity<UsersGroup>()
                .HasOne(sc => sc.User)
                .WithMany(c => c.Groups)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UsersGroup>()
                .HasOne(sc => sc.GroupRole)
                .WithMany(c => c.UsersGroups)
                .HasForeignKey(sc => sc.GroupRoleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}