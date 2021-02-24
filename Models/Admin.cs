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
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Please enter your username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string password { get; set; }
        //public string ReturnUrl { get; set; } = "/Admin/Login";
        public DateTime created_at = DateTime.Now;

    }
}