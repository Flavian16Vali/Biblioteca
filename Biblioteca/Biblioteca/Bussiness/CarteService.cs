using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Bussiness
{
    class BookService
    {
        private readonly BookRepository repository;

        public BookService()
        {
            repository = new BookRepository();
        }


        public void CreateBook(string title, string description, int yearPublished, int publisherId, List<int> authorIds)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Titlul este obligatoriu.");

            if (yearPublished < 1445 || yearPublished > DateTime.Now.Year)
                throw new ArgumentException($"Anul trebuie să fie între 1445 și {DateTime.Now.Year}.");

            if (publisherId <= 0)
                throw new ArgumentException("Selectați o editură validă.");

            if (authorIds == null || authorIds.Count == 0)
                throw new ArgumentException("Selectați cel puțin un autor.");

            Book book = new Book
            {
                Title = title,
                Description = description,
                YearPublished = yearPublished,
                PublisherId = publisherId,
                AuthorIds = authorIds
            };

            repository.CreateBook(book);
        }


        public void UpdateBook(int id, string title, string description, int yearPublished, int publisherId, List<int> authorIds)
        {
            if (id <= 0)
                throw new ArgumentException("Id-ul cartii este invalid!");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Titlul este obligatoriu.");

            if (yearPublished < 1445 || yearPublished > DateTime.Now.Year)
                throw new ArgumentException($"Anul trebuie sa fie între 1445 și {DateTime.Now.Year}.");

            if (publisherId <= 0)
                throw new ArgumentException("Selectati o editura valida.");

            if (authorIds == null || authorIds.Count == 0)
                throw new ArgumentException("Selectati cel putin un autor.");

            Book book = new Book
            {
                Id = id,
                Title = title,
                Description = description,
                YearPublished = yearPublished,
                PublisherId = publisherId,
                AuthorIds = authorIds
            };

            repository.UpdateBook(book);
        }


        public void DeleteBook(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID invalid.");

            repository.DeleteBook(id);
        }


        public List<Book> GetBooks()
        {
            return repository.GetBooks();
        }


        public Book GetBookById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID invalid.");

            return repository.GetBook(id);
        }


        public DataTable GetPublishers()
        {
            return repository.GetPublishers();
        }


        public DataTable GetAuthors()
        {
            return repository.GetAuthors();
        }


        public DataTable GetFilteredBooks(int? yearMin, int? yearMax, int? publisherId, int? authorId)
        {
            if (yearMin.HasValue && yearMax.HasValue && yearMin > yearMax)
                throw new ArgumentException("Anul minim nu poate fi mai mare decat anul maximmm.");

            if (publisherId.HasValue && publisherId <= 0)
                throw new ArgumentException("Eroare la editura.");

            if (authorId.HasValue && authorId <= 0)
                throw new ArgumentException("Eroare la autor.");

            return repository.GetFilteredBooks(yearMin, yearMax, publisherId, authorId);
        }

    }
}
