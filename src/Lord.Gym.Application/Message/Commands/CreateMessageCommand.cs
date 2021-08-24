using Lord.Gym.Infrastructure.Context;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lord.Gym.Application.Message.Commands
{
    public class CreateMessageCommand : IRequest<Lord.Gym.Domain.Entities.Message.Message>
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid From { get; set; }
        public string Room { get; set; }
    }

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Lord.Gym.Domain.Entities.Message.Message>
    {
        private readonly ApplicationDbContext _context;

        public CreateMessageCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Lord.Gym.Domain.Entities.Message.Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Name == request.Room);
            if (room == null)
                throw new Exception("Room not found");

            Lord.Gym.Domain.Entities.Message.Message message = new Lord.Gym.Domain.Entities.Message.Message
            {
                Timestamp = DateTime.UtcNow,
                Content = request.Content,
                RoomId = Guid.Parse("818DE18A-E8D5-4395-B31B-196A171B0D66"),
            };

            var result = _context.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }
    }
}