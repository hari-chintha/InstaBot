using System.Threading.Tasks;

namespace InstaBot.ProducerAPI.Commands
{
    public interface ICommandHandler
    {
        Task HandleAsync(NewUsernameComingInCommand command);
        
    }
}
