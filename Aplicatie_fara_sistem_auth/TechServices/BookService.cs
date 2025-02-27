﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TechData;
using TechData.Interfaces;
using TechData.Models;

namespace TechServices
{
    public class BookService : IBookService
    {
        private readonly TechContext _context;

        public BookService(TechContext context)
        {
            _context = context;
        }

        public void Add(Book newBook)
        {
            _context.Add(newBook);
            _context.SaveChanges();
        }

        public void Edit(Book editedBook)
        {
            _context.Entry(editedBook).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Book Get(int id)
        {
            return _context.Books.FirstOrDefault(book => book.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return _context.Books.Where(a => a.Author.Contains(author));
        }

        public IEnumerable<Book> GetByIsbn(string isbn)
        {
            return _context.Books.Where(a => a.ISBN == isbn);
        }
    }
}
