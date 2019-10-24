using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoModels
{
    public class SpendingDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int Category { get; set; }
    }
}
