using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Models;
using Scholia.Models.Interfaces;

namespace Scholia.Services.MockDB {
    public class MockBookData : IBookData{

        public List<Book> Books { get; set; }


        public MockBookData() {
            Books = new List<Book>() {
               new Book {Id = 1, Title="Moby Dick", Author = "Herman Melville", Body = "Thar She Blows!", GutenbergId = 1},
               new Book {Id = 2, Title="Brothers Karamazov", Author = "Fyodor Dostoevsky", Body = "God makes me happy, but also he doesn't?", GutenbergId = 2},
               new Book {Id = 3, Title="Dracula", Author = "Jaws, but with vampires."}
            };

        }

        public Book Fetch(int GutenID) {
            return this.Books.FirstOrDefault(b => b.GutenbergId == GutenID);
        }

        public IEnumerable<Book> GetAll() {
            return this.Books; 
        }

        public Book Get(int id) {
            return this.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}
