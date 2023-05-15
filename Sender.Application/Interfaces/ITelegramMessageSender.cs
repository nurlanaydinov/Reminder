namespace Sender.Application.Interfaces
{
    public interface ITelegramMessageSender
    {
        public void SendMessage(string number, string message);
    }
}
