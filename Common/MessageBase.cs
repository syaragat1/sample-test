namespace Upmc.ServiceBus.Messages
{
    public class MessageHeader
    {
        public int ClientId { get; set; }

        public int UserId { get; set; }
    }

    public class MessageBase
    {
        public MessageHeader Header { get; set; }
    }
}
