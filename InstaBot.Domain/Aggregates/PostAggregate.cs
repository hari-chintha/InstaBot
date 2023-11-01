using InstaBot.Application.Domain;
using InstaBot.Application.Events;

namespace InstaBot.Domain.Aggregates
{
    public class PostAggregate : AggregateRoot
    {
        private bool _active;
        public bool Active { get => _active; set => _active = value; }

        public PostAggregate()
        {
        }

        public PostAggregate(Guid id, string userName)
        {
            RaiseEvent(new NewUsernameComingInEvent
            {
                Id = id,
                Username = userName
            });
        }


        public void NewUsernameComingIn(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new InvalidOperationException($"The value of {nameof(username)} cannot be null or empty. Please provide a valid {nameof(username)}!");
            }

            RaiseEvent(new NewUsernameComingInEvent
            {
                Id = _id,
                Username = username
            });
        }

        public void Apply(NewUsernameComingInEvent _event)
        {
            _id = _event.Id;
            _active = true;
        }

        //public void EditUsername(string Username)
        //{
        //    if (!_active)
        //    {
        //        throw new InvalidOperationException("You cannot edit the message of an inactive post!");
        //    }

        //    if (string.IsNullOrWhiteSpace(message))
        //    {
        //        throw new InvalidOperationException($"The value of {nameof(message)} cannot be null or empty. Please provide a valid {nameof(message)}!");
        //    }

        //    RaiseEvent(new MessageUpdatedEvent
        //    {
        //        Id = _id,
        //        Message = message
        //    });
        //}

        //public void Apply(MessageUpdatedEvent @event)
        //{
        //    _id = @event.Id;
        //}
    }
}