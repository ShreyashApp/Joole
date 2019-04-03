using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JooleUI.Models
{
    public class UserLogin
    {
        [Required]
        [Display(Name ="Username or Email")]
        public string Login_Name { get; set; }

        [Required]
        [Display(Name ="Password")]
        public string User_Password { get; set; }

    }
}