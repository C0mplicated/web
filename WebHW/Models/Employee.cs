using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebHW.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Job { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}