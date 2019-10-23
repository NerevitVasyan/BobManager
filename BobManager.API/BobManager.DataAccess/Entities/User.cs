using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BobManager.DataAccess.Entities
{
    public class User :  IdentityUser
    {
        public ICollection<UsersGroup> Groups { get; set; }
    }
}