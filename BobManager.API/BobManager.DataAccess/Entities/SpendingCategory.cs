using System.ComponentModel.DataAnnotations;

namespace BobManager.DataAccess.Entities
{
    public class SpendingCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}