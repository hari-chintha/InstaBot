using InstaBot.Application.Events;

namespace InstaBot.Application.Producers
{
    public interface IEventProducer
    {
        Task ProduceAsync<T>(string topic, T @event) where T : BaseEvent;
    }
}