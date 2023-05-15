using Hangfire;
using MediatR;
using Sender.Application.Interfaces;
using Sender.Domain.Common.Commands;
using Sender.Domain.Entities;

namespace Sender.Application.Common
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand>
    {
        private readonly ISenderRepository _senderRepository;
        private readonly IReminderScheduler _reminderScheduler;
        public CreateCommandHandler(IReminderScheduler reminderScheduler, ISenderRepository senderRepository)
        {     
            _reminderScheduler = reminderScheduler;
            _senderRepository = senderRepository;
        }
        public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
        { 
            var jobId = BackgroundJob.Schedule(() => _reminderScheduler.SendReminder(request) , request.SendAt);

            var reminder = new Reminder
            {
                Content = request.Content,
                To = request.To,
                SendAt = request.SendAt.ToUniversalTime(),
                Method = request.Method,
                CreatedDate = DateTime.UtcNow,
                Version = 0
            };

            _senderRepository.Create(reminder);

            await Task.FromResult(true);
        }


    }
}
