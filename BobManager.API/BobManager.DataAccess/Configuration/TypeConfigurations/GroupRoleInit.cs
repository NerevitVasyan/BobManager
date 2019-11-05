using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration.TypeConfigurations
{
    public class GroupRoleInit : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            GroupRole[] groupRoles = new GroupRole[]
            {
                new GroupRole { Name = "Lol"},
                new GroupRole { Name = "Kek"},
                new GroupRole { Name = "Cheburek"},
                new GroupRole { Name = "Garold"},
                new GroupRole { Name = "Mona Liza" }

            };
            await context.Set<GroupRole>().AddRangeAsync(groupRoles);
        }
    }
}
