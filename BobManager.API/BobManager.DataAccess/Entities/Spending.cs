﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BobManager.DataAccess.Entities
{
    public class Spending
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [Column(TypeName ="money")]
        public double Value { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("SpendingCategory")]
        public int SpendingCategoryId { get; set; }
        public SpendingCategory SpendingCategory { get; set; }
    }
}