using Lord.Gym.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lord.Gym.Application.Interfaces
{
    public interface IUserService
    {
        AppUser Authenticate(string username, string password);

        Task<List<AppUser>> GetAll();

        AppUser GetById(Guid id);

        AppUser Create(AppUser user, string password);

        void Update(AppUser user, string password = null);

        void Delete(Guid id);
    }
}