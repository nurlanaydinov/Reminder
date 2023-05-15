using Sender.Domain.Common.Commands;

namespace Sender.Application.Interfaces
{
    public interface IReminderScheduler
    {
        void SendReminder(CreateCommand command);
    }
}
