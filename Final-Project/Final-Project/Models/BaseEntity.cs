using System;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        
    }
}
