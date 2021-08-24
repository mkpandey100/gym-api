using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lord.Core.SignalR.Interfaces
{
    public interface IUserConnectionManager
    {
        Task KeepUserConnection(Guid userId, string connectionId);

        Task RemoveUserConnection(string connectionId);
    }
}