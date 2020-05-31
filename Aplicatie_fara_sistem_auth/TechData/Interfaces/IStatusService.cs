using System.Collections.Generic;
using TechData.Models;

namespace TechData.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAll();
        Status Get(int id);
        void Add(Status newStatus);
    }
}
