using Sender.Domain.Common.Commands;
using Sender.Domain.Common.Queries;
using Sender.Domain.Entities;

namespace Sender.Application
{
    public interface ISenderRepository
    {
        public void Create(Reminder request);
        public List<Reminder> GetAll();
        public void Update(Reminder request);
        public List<Reminder> GetByIds(List<int> ids);
        public void Delete(List<Reminder> request);
    }
}
