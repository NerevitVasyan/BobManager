using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BobManager.DataAccess.Entities
{
    public class User :  IdentityUser
    {
        public ICollection<UsersGroup> Groups { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }
    }
}