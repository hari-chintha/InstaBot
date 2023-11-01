using InstaBot.Application.Handlers;
using InstaBot.Domain.Aggregates;
using System;
using System.Threading.Tasks;

namespace InstaBot.ProducerAPI.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

        public CommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
        {
            _eventSourcingHandler = eventSourcingHandler;
        }

        public async Task HandleAsync(NewUsernameComingInCommand command)
        {
            throw new NotFiniteNumberException();
        }
    }
}
