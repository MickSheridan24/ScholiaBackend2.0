using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Services.Models;

namespace Scholia.Services.DB {
    public class SQLBookData : IBookData {

        private ScholiaDbContext db; 

        public SQLBookData (ScholiaDbContext db) {
            this.db = db;
        }

        public Book Get(int id) {
            return db.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll() {
            return db.Books;
        }
    }
}
