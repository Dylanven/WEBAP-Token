using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace projetAPI2
{
   
   
        public class LoginModel
        {
            [Required(ErrorMessage = "Email Required")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Password Required")]
            public string Password { get; set; }
        }
    }
