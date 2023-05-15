using MediatR;

namespace Sender.Domain.Common.Commands
{
    public class DeleteCommand : IRequest
    {
        public List<int> Ids { get; set; }
    }
}
