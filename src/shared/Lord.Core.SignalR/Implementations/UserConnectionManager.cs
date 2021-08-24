using Lord.Core.SignalR.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lord.Core.SignalR.Implementations
{
    public class UserConnectionManager : IUserConnectionManager
    {
        private static Dictionary<Guid, HashSet<string>> userConnectionMap = new Dictionary<Guid, HashSet<string>>();
        private static string userConnectionMapLocker = string.Empty;

        public async Task KeepUserConnection(Guid userId, string connectionId)
        {
            if (!userConnectionMapLocker.Contains(connectionId))
            {
                lock (userConnectionMapLocker)
                {
                    userConnectionMap[userId].Add(connectionId);
                }
            }
        }

        public async Task RemoveUserConnection(string connectionId)
        {
            //Remove the connectionId of user
            lock (userConnectionMapLocker)
            {
                foreach (var userId in userConnectionMap.Keys)
                {
                    if (userConnectionMap.ContainsKey(userId))
                    {
                        if (userConnectionMap[userId].Contains(connectionId))
                        {
                            userConnectionMap[userId].Remove(connectionId);
                            break;
                        }
                    }
                }
            }
        }
    }
}