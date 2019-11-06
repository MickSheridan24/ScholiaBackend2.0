using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Models;
using Scholia.Models.Interfaces;
using Scholia.Services;
using Scholia.Services.GutenbergService;

namespace Scholia.Services.Data {
    public class GutenBookData : IBookFetcher {
        private ScholiaDbContext db;
        private GutenbergClient client = new GutenbergClient();


        public GutenBookData (ScholiaDbContext db) {
            this.db = db;
        }


        public Book Fetch(int id) {
            var book = client.GutenGet(id);

            if (book != null) {
                Add(book);
            }
            return book;
        }

        public Dictionary<Object, Object> Search(string query) {
            return client.GutenSearch(query);
        }


        private void Add(Book b) {

            db.Books.Add(b);
            db.SaveChanges();

        }

    }
}
