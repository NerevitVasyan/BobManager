using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration.TypeConfigurations
{
    public class SpendingsInit : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            Spending[] spendings = new Spending[]
            {
                new Spending
                {
                    Value = 15,
                    Date = DateTime.Now,
                    Description = "Buy some Coffee",
                    SpendingCategoryId = await context.Set<SpendingCategory>().FirstOrDefaultAsync(x=>x.Name == "Food"),
                    User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com")
                },
                new Spending
                {
                    Value = 50,
                    Date = DateTime.Now,
                    Description = "Buy some Shawarma",
                    SpendingCategoryId = await context.Set<SpendingCategory>().FirstOrDefaultAsync(x=>x.Name == "Food"),
                    User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com")
                },
                new Spending
                {
                    Value = 15,
                    Date = DateTime.Now,
                    Description = "Pay Comunalka",
                    SpendingCategoryId = await context.Set<SpendingCategory>().FirstOrDefaultAsync(x=>x.Name == "House"),
                    User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com")
                },                 
            };

            await context.Set<Spending>().AddRangeAsync(spendings);
        }
    }
}
