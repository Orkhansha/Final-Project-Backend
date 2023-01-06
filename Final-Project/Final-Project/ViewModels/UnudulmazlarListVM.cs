using Final_Project.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.ViewModels
{
    public class UnudulmazlarListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Images { get; set; }
        public string Rutbe { get; set; }
        public string Haqqinda { get; set; }
        public string MainImage { get; set; }
        public ICollection<UnudulmazlarImages> UnudulmazlarImages { get; set; }

    }
}
