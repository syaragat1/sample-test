using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upmc.ServiceBus.Messages;

namespace Upmc.ServiceBus.Messages
{
    public class Greeting3ReceivedEvent : IEvent
    {
        public string Greeting { get; set; }
    }
}
