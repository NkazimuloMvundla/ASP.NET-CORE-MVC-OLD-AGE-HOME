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
    public class User
    {
        [Key]
        public int UserId { get; set; }
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
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string ConfirmPassword { get; set; }
        [StringLength(100)]
        public string address { get; set; }
        public DateTime created_at = DateTime.Now;

    }
}