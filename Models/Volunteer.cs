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
    public class Volunteer
    {
        [Key]
        public int VolunteerId { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        public string name { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [Phone]
        public string phone { get; set; }
        [Required]
        public string event_name { get; set; }
        [Required]
        public string event_date { get; set; }
        [Required]
        public string time { get; set; }
        public DateTime created_at = DateTime.Now;

    }
}