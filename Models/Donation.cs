using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orphanage.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Orphanage.Models
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }
        [Required(ErrorMessage = "Please enter amount")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal amount { get; set; }
        public string donate_type { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please enter your Surname")]
        public string surname { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [Phone]
        public string phone { get; set; }
        [StringLength(100)]
        public string? message { get; set; }
        public DateTime created_at = DateTime.Now;
        
    }
}