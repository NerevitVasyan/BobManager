using System;
using System.ComponentModel.DataAnnotations;

namespace BobManager.Dto.DtoModels
{
    public class ToDoDto
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }        
        public ToDoCategoryDto ToDoCategoryDto { get; set; }
    }
}
