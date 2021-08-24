using Lord.Core.SignalR.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lord.Gym.API.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MessageHub : Hub
    {
        private readonly IUserConnectionManager _userConnectionManager;
        private const string ObjectIdClaim = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        public MessageHub(IUserConnectionManager userConnectionManager)
        {
            _userConnectionManager = userConnectionManager;
        }

        /// <summary>
        /// Connect and Keep user in dictionary with signalId
        /// </summary>
        public override async Task OnConnectedAsync()
        {
            var httpContext = this.Context.GetHttpContext();
            Guid userId = Guid.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type == ObjectIdClaim).Value);
            await _userConnectionManager.KeepUserConnection(userId, Context.ConnectionId);
            await Clients.All.SendAsync("onConnectedAsync", $"{Context.ConnectionId}");
            await Clients.All.SendAsync("onUserActive", userId);
        }

        /// <summary>
        /// Called when a connection with the hub is terminated.
        /// </summary>
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = this.Context.GetHttpContext();
            Guid userId = Guid.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type == ObjectIdClaim).Value);
            //get the connectionId
            var connectionId = Context.ConnectionId;
            await _userConnectionManager.RemoveUserConnection(connectionId);
            var value = await Task.FromResult(0);
            await Clients.All.SendAsync("onUserInActive", userId);
        }
    }
}