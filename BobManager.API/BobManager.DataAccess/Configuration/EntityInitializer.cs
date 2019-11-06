using BobManager.DataAccess.Configuration.TypeConfigurations;
using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration
{
    public class EntityInitializer : IEntityInitializer
    {
        private readonly List<ITypeInitializer> typeInitializers;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DbContext context;

        public EntityInitializer(UserManager<User> _userManager,
                                 RoleManager<IdentityRole> _roleManager,
                                 DbContext _context)
        {
            typeInitializers = new List<ITypeInitializer>();
            userManager = _userManager;
            roleManager = _roleManager;
            context = _context;

            this.AddConfig(new SpendingCategoryInit());
            this.AddConfig(new SpendingsInit());
            this.AddConfig(new GroupInit());
            this.AddConfig(new GroupRoleInit());
            this.AddConfig(new ToDoCategoryInit());
            this.AddConfig(new ToDoInit());
            this.AddConfig(new CalendarEventInit());
            //this.AddConfig(new UsersGroupInit());
        }

        public void AddConfig(ITypeInitializer typeInitializer)
        {
            typeInitializers.Add(typeInitializer);
        }

        public async Task SeedData()
        {
            //bool deleted = await context.Database.EnsureDeletedAsync();
            //bool created = await context.Database.EnsureCreatedAsync();

            await InitializeIdetity();
            foreach(var initializer in typeInitializers)
            {
                await initializer.Init(context);
            }
            await context.SaveChangesAsync();
        }

        private async Task InitializeIdetity()
        {
            await roleManager.CreateAsync(new IdentityRole { Name = "admin" });

            await userManager.CreateAsync(new User
            {
                UserName = "vasyan@gmail.com",
                Email = "vasyan@gmail.com"
            }, "Qwe123!!");

            await userManager.CreateAsync(new User
            {
                UserName = "petro@gmail.com",
                Email = "petro@gmail.com"
            }, "Qwe123!!");

            await userManager.CreateAsync(new User
            {
                UserName = "shliapa@gmail.com",
                Email = "shliapa@gmail.com",
            }, "Qwe123!!");

            await userManager.CreateAsync(new User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com"
            }, "Qwe123!!");

            var admin = await userManager.FindByEmailAsync("admin@gmail.com");
            await userManager.AddToRoleAsync(admin, "admin"); 
        }
    }
}