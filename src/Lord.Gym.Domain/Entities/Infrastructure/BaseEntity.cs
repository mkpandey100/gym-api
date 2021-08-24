using System;
using System.Collections.Generic;
using System.Text;

namespace Lord.Gym.Domain.Entities.Infrastructure
{
    public class BaseEntity
    {
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}