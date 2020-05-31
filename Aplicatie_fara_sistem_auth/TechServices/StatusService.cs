using System.Collections.Generic;
using System.Linq;
using TechData;
using TechData.Interfaces;
using TechData.Models;

namespace TechServices
{
    public class StatusService : IStatusService
    {
        private readonly TechContext _context;

        public StatusService(TechContext context)
        {
            _context = context;
        }

        public void Add(Status newStatus)
        {
            _context.Add(newStatus);
            _context.SaveChanges();
        }

        public Status Get(int id)
        {
            return _context.Statuses.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Statuses;
        }
    }
}
