using System.ComponentModel.DataAnnotations.Schema;

namespace BobManager.DataAccess.Entities
{
    public class UsersGroup
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [ForeignKey("GroupRole")]
        public int GroupRoleId { get; set; }
        public GroupRole GroupRole { get; set; }
    }
}