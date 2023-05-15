using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender.Domain.Telegram.Commands
{
    public class TelegramCommand : IRequest
    {
        public string ChatId { get; set; }
        public string Text { get; set; }
    }
}
