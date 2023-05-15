namespace Sender.Application.Interfaces
{
    public interface IValidator
    {
        bool IsValidNumber(string number);
        bool IsValidEmail(string email);
    }
}
