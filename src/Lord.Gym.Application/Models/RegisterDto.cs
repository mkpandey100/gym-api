using System;
using System.Collections.Generic;
using System.Text;

namespace Lord.Gym.Application.Models
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailConfirmed { get; set; }
        public string Password { get; set; }
    }
}