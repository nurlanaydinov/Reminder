namespace Sender.Application.Interfaces
{
    public interface IEmailSender
    {
        public void Send(string email, string subject, string message);
    }
}
