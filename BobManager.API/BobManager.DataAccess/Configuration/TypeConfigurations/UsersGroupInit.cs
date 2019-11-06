using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration.TypeConfigurations
{
    public class UsersGroupInit : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            UsersGroup[] usersGroupInits = new UsersGroup[]
            {
                new UsersGroup
                {
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x=> x.Name == "Donner"),
                   GroupRole = await context.Set<GroupRole>().FirstOrDefaultAsync(x=> x.Name == "Lol")
                },
                new UsersGroup
                {
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x=> x.Name == "Mackdack"),
                   GroupRole = await context.Set<GroupRole>().FirstOrDefaultAsync(x=> x.Name == "Cheburek")
                },
                new UsersGroup
                {
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x=> x.Name == "Apachi"),
                   GroupRole = await context.Set<GroupRole>().FirstOrDefaultAsync(x=> x.Name == "Lol")
                },
                new UsersGroup
                {
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x=> x.Name == "Gays"),
                   GroupRole = await context.Set<GroupRole>().FirstOrDefaultAsync(x=> x.Name == "Kek")
                },
                new UsersGroup
                {
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x=> x.Name == "Unforms"),
                   GroupRole = await context.Set<GroupRole>().FirstOrDefaultAsync(x=> x.Name == "Garold")
                },
            };
            await context.Set<UsersGroup>().AddRangeAsync(usersGroupInits);

        }
    }
}
