using MediatR;
using Sender.Domain.Common.Commands;

namespace Sender.Application.Common
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly ISenderRepository _senderRepository;
        public DeleteCommandHandler(ISenderRepository repository)
        {
            _senderRepository = repository;
        }
        public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var reminders = _senderRepository.GetByIds(request.Ids);
            if (reminders.Any()) _senderRepository.Delete(reminders);
            await Task.FromResult(true);
        }
    }
}
