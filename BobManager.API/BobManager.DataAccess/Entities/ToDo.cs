using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BobManager.DataAccess.Entities
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("ToDoCategory")]
        public int CategoryId { get; set; }
        public ToDoCategory ToDoCategory { get; set; }
    }
}