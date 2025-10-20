using MediatR;

namespace CQRSDemo1.Features.Players.CreatePlayer
{
    public class CreatePlayerCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}
