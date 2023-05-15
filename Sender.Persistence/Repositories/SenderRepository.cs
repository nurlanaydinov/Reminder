using Microsoft.EntityFrameworkCore;
using Sender.Application;
using Sender.Domain.Entities;

namespace Sender.Persistence.Repositories
{
    public class SenderRepository : ISenderRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<Reminder> _entities;
        public SenderRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<Reminder>();
        }
        public void Create(Reminder request)
        {
            _entities.Add(request);
            _context.SaveChanges();
            
        }

        public void Delete(List<Reminder> request)
        {
            _entities.RemoveRange(request);
            _context.SaveChanges();
            
        }

        public List<Reminder> GetAll()
        {
            return _entities.ToList();
        }

        public List<Reminder> GetByIds(List<int> ids)
        {
            return _entities.Where(e => ids.Contains(e.Id)).ToList();
        }

        public void Update(Reminder request)
        {
            var entity = _entities.Find(request.Id);
            if (entity != null)
            {
                entity.To = request.To;
                entity.SendAt = request.SendAt;
                entity.Content = request.Content;
                entity.Version = 0;
                _context.SaveChanges();
            }                  
        }
    }
}
