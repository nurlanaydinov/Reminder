using MediatR;
using Sender.Application.Interfaces;
using Sender.Domain.Telegram.Commands;

namespace Sender.Application.Telegram
{
    public class TelegramCommandHandler : IRequestHandler<TelegramCommand>
    {
        private readonly ITelegramMessageSender _telegramMessageSender;
        public TelegramCommandHandler(ITelegramMessageSender telegramMessageSender)
        {         
            _telegramMessageSender = telegramMessageSender;
        }
        public async Task Handle(TelegramCommand request, CancellationToken cancellationToken)
        {
            _telegramMessageSender.SendMessage(request.ChatId, request.Text);
             await Task.FromResult(true);
        }
    }
}
