using Sender.Application.Interfaces;
using System.Text.RegularExpressions;

namespace Sender.Application.Exceptions
{
    public class Validator : IValidator
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsValidNumber(string number)
        {
            string pattern = @"^\+\d{1,3}-\d{1,}-\d{1,}$";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(number);

            return match.Success;

        }
    }
}
