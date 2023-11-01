using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Application.Events
{
    public class NewUsernameComingInEvent : BaseEvent
    {
        public NewUsernameComingInEvent(): base(nameof(NewUsernameComingInEvent))
        {
        }

        public string Username { get; set; }
    }
}
