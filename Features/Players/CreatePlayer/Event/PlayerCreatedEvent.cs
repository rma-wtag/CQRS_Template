using MediatR;

namespace CQRSDemo1.Features.Players.CreatePlayer.Event
{
    public class PlayerCreatedEvent : INotification
    {
        public int PlayerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}
