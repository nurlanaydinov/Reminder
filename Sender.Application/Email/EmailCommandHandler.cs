using MediatR;
using Sender.Application.Interfaces;
using Sender.Domain.Email.Commands;

namespace Sender.Application.Email
{
    public class EmailCommandHandler : IRequestHandler<EmailCommand>
    {      
        private readonly IEmailSender _emailSender;
        public EmailCommandHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Handle(EmailCommand request, CancellationToken cancellationToken)
        {
            _emailSender.Send(request.To, "", request.Text);

            await Task.FromResult(true);
        }
    }
}
