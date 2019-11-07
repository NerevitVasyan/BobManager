using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration.TypeConfigurations
{
    public class SpendingCategoryInit : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            SpendingCategory[] spendingCategories = new SpendingCategory[]
            {
                new SpendingCategory { Name = "Food", Color = "Green" },
                new SpendingCategory { Name = "House", Color = "Blue" },
                new SpendingCategory { Name = "Alcohol", Color = "Red" },
                new SpendingCategory { Name = "School", Color = "Orange" },
                new SpendingCategory { Name = "Dreams", Color = "Green" }
            };

            await context.Set<SpendingCategory>().AddRangeAsync(spendingCategories);
        }
    }
}