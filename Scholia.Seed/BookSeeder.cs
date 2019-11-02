using Scholia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Seed {
    public class BookSeeder {
        private ScholiaDbContext db;
        

        public BookSeeder(ScholiaDbContext db) {
            this.db = db; 

        }

        public void Seed(IBookData mock) {
            var books = mock.GetAll();
            foreach (var book in books) {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }
    }
}
