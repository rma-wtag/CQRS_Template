using CQRSDemo1.Models;
using MediatR;

namespace CQRSDemo1.Features.Players.GetPlayerById
{
    public class GetPlayerByIdQuery : IRequest<Player?>
    {
        public int Id { get; set; }
    }
}
