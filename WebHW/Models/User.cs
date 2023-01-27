using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebHW.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter name minimum: 4 letters and maximum: 20 letters")]
        [StringLength(20,MinimumLength = 4)]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress]
        public string email { get; set; }

        [Required (ErrorMessage ="Please enter the password")]
        public string password { get; set; }

        [Required (ErrorMessage = "Please enter the same password")]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string confirmPass { get; set; }

 
        //[Required(ErrorMessage ="Please choose file to upload")]
        public HttpPostedFileBase file { get; set; }


    }
}