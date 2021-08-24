using Lord.Gym.Domain.Entities.Auth;
using Lord.Gym.Domain.Entities.Exercise;
using Lord.Gym.Domain.Entities.Message;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lord.Gym.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        #region =============Exercise================

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        #endregion =============Exercise================

        #region =============Messaging================

        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }

        #endregion =============Messaging================
    }
}