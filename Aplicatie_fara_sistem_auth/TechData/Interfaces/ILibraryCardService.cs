using System.Collections.Generic;
using TechData.Models;

namespace TechData.Interfaces
{
    public interface ILibraryCardService
    {
        IEnumerable<LibraryCard> GetAll();
        LibraryCard Get(int id);
        void Add(LibraryCard newCard);
    }
}
