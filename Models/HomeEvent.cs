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
    public class HomeEvent
    {
        [Key]
        public int ActivityId { get; set; }
        [Required(ErrorMessage = "Please enter Activity Name")]
        public string event_name { get; set; }
        [Required(ErrorMessage = "Please enter Activity Date")]
        public string event_date { get; set; }
        [Required(ErrorMessage = "Please enter Activity Time")]
		public string time { get; set; }
        public string? discription { get; set; }
        public DateTime created_at = DateTime.Now;

    }
}