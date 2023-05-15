using MediatR;
using Sender.Application.Interfaces;
using Sender.Domain.Common.Commands;
using Sender.Domain.Email.Commands;
using Sender.Domain.Telegram.Commands;

namespace Sender.Application.Common
{
    public class ReminderScheduler : IReminderScheduler
    {
        private readonly IMediator _mediatr;
        public ReminderScheduler(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        public void SendReminder(CreateCommand command)
        {
            if (command.Method == "telegram")
            {
                var telegramCommand = new TelegramCommand
                {
                    ChatId = command.To,
                    Text = command.Content
                };

                _mediatr.Send(telegramCommand);
            }
            else if (command.Method == "email")
            {
                var emailCommand = new EmailCommand
                {
                    To = command.To,
                    Text=command.Content
                };

                _mediatr.Send(emailCommand);
            }
        }
    }
}
