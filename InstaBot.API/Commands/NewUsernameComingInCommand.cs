using InstaBot.Application.Commands;
using InstaBot.Application.Handlers;
using InstaBot.Domain.Aggregates;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstaBot.ProducerAPI.Commands
{
    public class NewUsernameComingInCommand : BaseCommand, IRequest
    {
        public string Username { get; set; }
    }

    public class NewUsernameComingInCommandHandler : IRequestHandler<NewUsernameComingInCommand>
    {
        private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

        public NewUsernameComingInCommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
        {
            _eventSourcingHandler = eventSourcingHandler;
        }

        public async Task Handle(NewUsernameComingInCommand command, CancellationToken cancellationToken)
        {

            var aggregate = new PostAggregate(command.Id, command.Username);

            await _eventSourcingHandler.SaveAsync(aggregate);

        }
    }
}
