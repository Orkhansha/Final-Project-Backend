using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Final_Project.Models
{
    public class Order:BaseEntity
    {
        

        

        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Apartment { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string Phone { get; set; }

        public bool BankTransfer { get; set; }
        public bool CheckPayments { get; set; }

        public bool Paypal { get; set; }

        public bool CashOnDelivery { get; set; }
        public string Message { get; set; }

        public string Country { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool? Status { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
