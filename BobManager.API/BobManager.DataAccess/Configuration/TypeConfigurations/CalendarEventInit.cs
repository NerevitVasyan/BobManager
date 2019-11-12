using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Configuration.TypeConfigurations
{
    public class CalendarEventInit: ITypeInitializer
    {
        public async Task Init(DbContext context)
        {
            CalendarEvent[] calendarEvents = new CalendarEvent[]
            {
                new CalendarEvent
                {
                    Name = "Horror",
                    Description = "Something scary",
                    Date = new DateTime(2019,9,29),
                    Color = "Red",
                    User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="vasyan@gmail.com"),
                    Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Gays")
                },
                new CalendarEvent
                {
                    Name = "IT conference",
                    Description = "technologys about bla blA BLA",
                    Date = new DateTime(2019,10,1),
                    Color = "Yellow",
                    User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                    Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Apachi")
                },
                new CalendarEvent
                {
                    Name = "Johnson",
                    Description = "Something scary",
                    Date = new DateTime(2019,12,20),
                    Color = "Green",
                    User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                    Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack")
                },
                new CalendarEvent
                {
                    Name = "Disko",
                    Description = "Dj Slash with your mother",
                    Date = new DateTime(2019,12,31),
                    Color = "Green",
                    User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="shliapa@gmail.com"),
                    Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Unforms")
                },
                new CalendarEvent
                {
                    Name = "Marokko balance",
                    Description = "Ecology should be in first place in your heart",
                    Date = new DateTime(2020,1,12),
                    Color = "Red",
                    User = await context.Set<User>().FirstOrDefaultAsync(x=>x.Email=="petro@gmail.com"),
                    Group = await context.Set<Group>().FirstOrDefaultAsync(x => x.Name == "Mackdack")
                }
            };

            await context.Set<CalendarEvent>().AddRangeAsync(calendarEvents);
        }
    }
}