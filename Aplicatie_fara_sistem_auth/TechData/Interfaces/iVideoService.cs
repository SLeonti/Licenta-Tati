using System.Collections.Generic;
using TechData.Models;

namespace TechData.Interfaces
{
    public interface IVideoService
    {
        IEnumerable<Video> GetAll();
        IEnumerable<Video> GetByDirector(string author);
        Video Get(int id);
        void Add(Video newVideo);
        void Edit(Video editedVideo);
    }
}
