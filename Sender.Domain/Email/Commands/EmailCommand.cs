using MediatR;

namespace Sender.Domain.Email.Commands
{
    public class EmailCommand : IRequest
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Text { get; set; }
    }
}
