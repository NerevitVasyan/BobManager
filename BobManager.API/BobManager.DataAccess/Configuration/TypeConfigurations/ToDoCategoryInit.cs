using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration.TypeConfigurations
{
    public class ToDoCategoryInit : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            ToDoCategory[] toDoCategories = new ToDoCategory[]
            {
                new ToDoCategory { Name = "Work", Color = "Red"},
                new ToDoCategory { Name = "Housework", Color = "Yellow"},
                new ToDoCategory { Name = "Social", Color = "Orange"},
                new ToDoCategory { Name = "Entertaiment", Color = "Green"},
                new ToDoCategory { Name = "Promises", Color = "Phiolet"}
            };
            await context.Set<ToDoCategory>().AddRangeAsync(toDoCategories);
        }
    }
}
