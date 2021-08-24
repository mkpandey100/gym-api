using AutoMapper;
using Lord.Core.API.Controllers;
using Lord.Gym.API.Hubs;
using Lord.Gym.Application.Message.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Lord.Gym.API.Controllers.v1.Message
{
    [Route("api/v1/[controller]")]
    public class MessageController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageController(IMapper mapper, IHubContext<MessageHub> hubContext)
        {
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMessageCommand command)
        {
            var result = await Mediator.Send(command);
            await _hubContext.Clients.Group(result.ToRoom.Name).SendAsync("newMessage", result);
            return Ok();
        }
    }
}