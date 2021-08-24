using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Lord.Gym.Domain.Entities.Auth
{
    // Add profile data for application users by adding properties to this class
    public class AppUser : IdentityUser<Guid>
    {
        // Extended Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}