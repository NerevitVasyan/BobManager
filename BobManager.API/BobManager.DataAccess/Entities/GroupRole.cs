using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BobManager.DataAccess.Entities
{
    public class GroupRole
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UsersGroup> UsersGroups { get; set; }
    }
}