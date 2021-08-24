using Lord.Gym.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lord.Gym.Domain.Interfaces
{
    public interface IUserService
    {
        AppUser Authenticate(string username, string password);

        IEnumerable<AppUser> GetAll();

        AppUser GetById(Guid id);

        AppUser Create(AppUser user, string password);

        void Update(AppUser user, string password = null);

        void Delete(Guid id);
    }
}