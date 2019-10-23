using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoModels
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int? GroupId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
