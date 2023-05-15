using MediatR;
using Sender.Domain.Common.Commands;
using Sender.Domain.Entities;

namespace Sender.Application.Common
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
    {
        private readonly ISenderRepository _senderRepository;
        public UpdateCommandHandler(ISenderRepository repository)
        {
            _senderRepository = repository;
        }
        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var reminder = new Reminder
            {
                Id = request.Id,
                Content = request.Content,
                To = request.To,
                SendAt = request.SendAt.ToUniversalTime(),
                Method = request.Method,
                CreatedDate = DateTime.UtcNow,
                Version = 0
            };

            _senderRepository.Update(reminder);
            await Task.FromResult(true);
        }
    }
}
