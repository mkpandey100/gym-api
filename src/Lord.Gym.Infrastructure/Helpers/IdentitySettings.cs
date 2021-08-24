using System;
using System.Collections.Generic;
using System.Text;

namespace Lord.Gym.Infrastructure.Helpers
{
    public class IdentitySettings
    {
        public string SecretKey { get; set; }
        public string Expiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}