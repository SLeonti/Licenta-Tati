using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TechData;
using TechData.Interfaces;
using TechData.Models;

namespace TechServices
{
    public class VideoService : IVideoService
    {
        private readonly TechContext _context;

        public VideoService(TechContext context)
        {
            _context = context;
        }

        public IEnumerable<Video> GetAll()
        {
            return _context.Videos;
        }

        public IEnumerable<Video> GetByDirector(string director)
        {
            return _context.Videos.Where(a => a.Director.Contains(director));
        }

        public void Add(Video newVideo)
        {
            _context.Add(newVideo);
            _context.SaveChanges();
        }

        public Video Get(int id)
        {
            return _context.Videos.FirstOrDefault(v => v.Id == id);
        }

        public void Edit(Video editedVideo)
        {
            _context.Entry(editedVideo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
