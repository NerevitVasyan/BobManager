using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration.TypeConfigurations
{
    public class ToDoInit : ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            ToDo[] toDos = new ToDo[]
            {
                new ToDo
                {
                   Description = "Put your money into bag",
                   Deadline = new DateTime(2019, 7, 20),
                   Status = 5,
                   Priority = 10,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Donner"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Work")
                },              
                new ToDo
                {
                   Description = "Don't judje yourself",
                   Deadline = new DateTime(2019, 2, 13),
                   Status = 7,
                   Priority = 8,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Social")
                },
                new ToDo
                {
                   Description = "Travaling without document is dangerous",
                   Deadline = new DateTime(2019, 3, 11),
                   Status = 8,
                   Priority = 5,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Gays"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Work")
                },
                new ToDo
                {
                   Description = "Find girl for breakfast",
                   Deadline = new DateTime(2020, 7, 20),
                   Status = 5,
                   Priority = 0,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Apachi"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Housework")
                },new ToDo
                {
                   Description = "Put your money into bag",
                   Deadline = new DateTime(2019, 7, 20),
                   Status = 5,
                   Priority = 10,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Entertaiment")
                },new ToDo
                {
                   Description = "Do homework",
                   Deadline = new DateTime(2020, 12, 12),
                   Status = 3,
                   Priority = 3,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Promises")
                },new ToDo
                {
                   Description = "Without sence",
                   Deadline = new DateTime(2020, 9, 3),
                   Status = 7,
                   Priority = 10,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Unforms"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Work")
                },new ToDo
                {
                   Description = "Enter a gym",
                   Deadline = new DateTime(2045, 2, 3),
                   Status = 5,
                   Priority = 10,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Housework")
                },
                new ToDo
                {
                   Description = "Rob a bank",
                   Deadline = new DateTime(2021, 5, 3),
                   Status = 1,
                   Priority = 9,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Apachi"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Promises")
                },
                new ToDo
                {
                   Description = "Try to find a job",
                   Deadline = new DateTime(2123, 1, 1),
                   Status = 1,
                   Priority = 1,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Donner"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Work")
                },
                new ToDo
                {
                   Description = "Level Up",
                   Deadline = new DateTime(2019, 2, 3),
                   Status = 2,
                   Priority = 5,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Apachi"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Social")
                },
                new ToDo
                {
                   Description = "Johnys house",
                   Deadline = new DateTime(2020, 2, 5),
                   Status = 4,
                   Priority = 3,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Gays"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Housework")
                },
                new ToDo
                {
                   Description = "Buy a gun",
                   Deadline = new DateTime(2020, 12, 1),
                   Status = 5,
                   Priority = 7,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Unforms"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Promises")
                },
                new ToDo
                {
                   Description = "Introduse yourself",
                   Deadline = new DateTime(2021, 5, 15),
                   Status = 5,
                   Priority = 7,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Unforms"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Social")
                },
                new ToDo
                {
                   Description = "Invite John's mom to the Resturant",
                   Deadline = new DateTime(2020, 5, 17),
                   Status = 2,
                   Priority = 7,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Entertaiment")
                },
                new ToDo
                {
                   Description = "Enjoy your life",
                   Deadline = new DateTime(2099, 12, 31),
                   Status = 3,
                   Priority = 0,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Apachi"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Work")
                },
                new ToDo
                {
                   Description = "Go to gym",
                   Deadline = new DateTime(2019, 3, 4),
                   Status = 2,
                   Priority = 10,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Donner"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Social")
                },
                new ToDo
                {
                   Description = "Follow God",
                   Deadline = new DateTime(2021, 12, 21),
                   Status = 9,
                   Priority = 0,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Apachi"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Housework")
                },
                new ToDo
                {
                   Description = "Find your father",
                   Deadline = new DateTime(2020, 12, 4),
                   Status = 2,
                   Priority = 4,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Work")
                },
                new ToDo
                {
                   Description = "Create your own buisness",
                   Deadline = new DateTime(2025, 12, 31),
                   Status = 1,
                   Priority = 10,
                   Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack"),
                   User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                   ToDoCategory = await context.Set<ToDoCategory>().FirstOrDefaultAsync(x=> x.Name == "Social")
                },
            };

            await context.Set<ToDo>().AddRangeAsync(toDos);
        }
    }
}