using System.Collections.Generic;
using System.Linq;
using TechData;
using TechData.Interfaces;
using TechData.Models;

namespace TechServices
{
    public class LibraryCardService : ILibraryCardService
    {
        private readonly TechContext _context;

        public LibraryCardService(TechContext context)
        {
            _context = context;
        }

        public void Add(LibraryCard newLibraryCard)
        {
            _context.Add(newLibraryCard);
            _context.SaveChanges();
        }

        public LibraryCard Get(int cardId)
        {
            return _context.LibraryCards.FirstOrDefault(p => p.Id == cardId);
        }

        public IEnumerable<LibraryCard> GetAll()
        {
            return _context.LibraryCards;
        }
    }
}
