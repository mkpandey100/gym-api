using Lord.Gym.Domain.Entities.Auth;
using System;
using System.Collections.Generic;

namespace Lord.Gym.Domain.Entities.Message
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AppUser User { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}