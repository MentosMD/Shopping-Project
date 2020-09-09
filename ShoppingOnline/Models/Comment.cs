using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.Models
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }
        public string CreatedAt { get; set; }
        public int ProfileRef { get; set; }
        public Profile Profile { get; set; }
        public bool IsEdited { get; set; }
    }
}