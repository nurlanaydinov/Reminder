using MediatR;
using Sender.Domain.Common.Queries;
using Sender.Domain.Entities;

namespace Sender.Application.Common
{
    public class ReadCommandHandler : IRequestHandler<ReadCommand, List<Reminder>>
    {
        private readonly ISenderRepository _senderRepository;
        public ReadCommandHandler(ISenderRepository repository)
        {
            _senderRepository = repository;
        }
        public async Task<List<Reminder>> Handle(ReadCommand request, CancellationToken cancellationToken)
        {
            var viewModel = new List<Reminder>();
            viewModel = _senderRepository.GetAll();
            return await Task.FromResult(viewModel);
        }
    }
}
