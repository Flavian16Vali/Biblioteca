using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class Book
    {
        private int id;
        private string title;
        private int yearPublished;
        private string description;

        private int publisherId;
        private string publisherName;
        private List<int> authorIds;
        private string authorNames;

        public Book()
        {
            authorIds = new List<int>();
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int YearPublished { get => yearPublished; set => yearPublished = value; }
        public string Description { get => description; set => description = value; }
        public int PublisherId { get => publisherId; set => publisherId = value; }
        public string PublisherName { get => publisherName; set => publisherName = value; }
        public List<int> AuthorIds { get => authorIds; set => authorIds = value; }
        public string AuthorNames { get => authorNames; set => authorNames = value; }
    }
}
