using CQRSDemo1.Data;
using CQRSDemo1.Models;
using MediatR;

namespace CQRSDemo1.Features.Players.CreatePlayer.Event
{
    public class PlayerCreatedEventHandler : INotificationHandler<PlayerCreatedEvent>
    {
        private readonly AppReadDbContext _context;

        public PlayerCreatedEventHandler(AppReadDbContext context)
        {
            _context = context;
        }
        public async Task Handle(PlayerCreatedEvent notification, CancellationToken cancellationToken)
        {
            _context.Players.Add(new Player
            {
                Id = notification.PlayerId,
                Name = notification.Name,
                Level = notification.Level
            });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
