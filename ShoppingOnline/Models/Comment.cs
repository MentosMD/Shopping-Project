using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.Models
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }
    }
}