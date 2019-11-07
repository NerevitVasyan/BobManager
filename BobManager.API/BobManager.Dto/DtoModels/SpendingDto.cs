using System;

namespace BobManager.Dto.DtoModels
{
    public class SpendingDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public SpendingCategoryDto SpendingCategory { get; set; }
    }
}