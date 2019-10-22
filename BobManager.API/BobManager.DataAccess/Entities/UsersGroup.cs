using System.ComponentModel.DataAnnotations.Schema;

namespace BobManager.DataAccess.Entities
{
    public class UsersGroup
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        [ForeignKey("GroupRole")]
        public int GroupRoleId { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
        public GroupRole GroupRole { get; set; }
    }
}