namespace interception.application
{
    public class MessageService : IMessageService
    {
        public string GetHelloMessage()
        {
            return "Hello World!!";
        }
    }
}