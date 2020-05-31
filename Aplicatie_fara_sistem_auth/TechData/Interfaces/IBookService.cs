using System.Collections.Generic;
using TechData.Models;

namespace TechData.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetByAuthor(string author);
        IEnumerable<Book> GetByIsbn(string isbn);
        Book Get(int id);
        void Add(Book newBook);
        void Edit(Book editedBook);
    }
}
