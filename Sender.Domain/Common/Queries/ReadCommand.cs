using MediatR;
using Sender.Domain.Entities;

namespace Sender.Domain.Common.Queries
{
    public class ReadCommand : IRequest<List<Reminder>>
    {

    }
}
