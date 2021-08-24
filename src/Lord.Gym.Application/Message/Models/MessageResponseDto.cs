using System;
using System.Collections.Generic;
using System.Text;

namespace Lord.Gym.Application.Message.Models
{
    public class MessageResponseDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string From { get; set; }
        public string Room { get; set; }
    }
}