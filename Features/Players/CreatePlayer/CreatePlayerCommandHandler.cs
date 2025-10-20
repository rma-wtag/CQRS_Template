using CQRSDemo1.Data;
using CQRSDemo1.Features.Players.CreatePlayer.Event;
using CQRSDemo1.Models;
using MediatR;

namespace CQRSDemo1.Features.Players.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly AppWriteDbContext _context;
        private readonly IMediator _mediator;
        public CreatePlayerCommandHandler(AppWriteDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player { Name = request.Name , Level = request.Level};
            _context.Players.Add(player);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new PlayerCreatedEvent { PlayerId = player.Id, Name = player.Name, Level = player.Level },cancellationToken);

            return player.Id;
        }
    }
}
