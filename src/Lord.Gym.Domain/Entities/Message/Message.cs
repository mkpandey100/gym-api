using Lord.Gym.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lord.Gym.Domain.Entities.Message
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public AppUser User { get; set; }
        public Guid RoomId { get; set; }
        public Room ToRoom { get; set; }
    }
}