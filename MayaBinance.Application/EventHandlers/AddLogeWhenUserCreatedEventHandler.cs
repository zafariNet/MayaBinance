using System.Threading;
using System.Threading.Tasks;
using MayaBinance.Domain.Identity.Users.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MayaBinance.Application.EventHandlers
{
    public class AddLogeWhenUserCreatedEventHandler:INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<AddLogeWhenUserCreatedEventHandler> _logger;

        public AddLogeWhenUserCreatedEventHandler(ILogger<AddLogeWhenUserCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.Log(logLevel:LogLevel.Information,$"User : {notification.FirstName} {notification.LastName} Registered");
            return Task.CompletedTask;
        }
    }
}
