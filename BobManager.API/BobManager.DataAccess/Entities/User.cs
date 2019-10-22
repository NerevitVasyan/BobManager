using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BobManager.DataAccess.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<UsersGroup> Groups { get; set; }
    }
}