﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lord.Gym.Domain.Entities.Infrastructure
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}