using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Final_Project.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsActive { get; set; } = false;
        public List<BasketItem> BasketItems { get; set; }

    }
}
