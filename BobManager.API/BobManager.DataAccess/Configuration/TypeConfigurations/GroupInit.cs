using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration.TypeConfigurations
{
    public class GroupInit : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            Group[] groups = new Group[]
            {
                new Group { Name = "Donner"},
                new Group { Name = "Mackdack"},
                new Group { Name = "Apachi"},
                new Group { Name = "Gays"},
                new Group { Name = "Unforms"}
            };

            await context.Set<Group>().AddRangeAsync(groups);
        }
    }
}