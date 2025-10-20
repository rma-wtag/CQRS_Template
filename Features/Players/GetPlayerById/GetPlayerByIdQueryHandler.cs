using CQRSDemo1.Data;
using CQRSDemo1.Models;
using MediatR;

namespace CQRSDemo1.Features.Players.GetPlayerById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player?>
    {
        private readonly AppReadDbContext _context;

        public GetPlayerByIdQueryHandler(AppReadDbContext context)
        {
            _context = context;
        }
        public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.Id);

            return player;
        }
    }
}
