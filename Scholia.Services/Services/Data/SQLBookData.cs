using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Models;
using Scholia.Models.Interfaces;

namespace Scholia.Services.Data {
    public class SQLBookData : IBookData, IBookFetcher {

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

        Book IBookFetcher.Get(int id) {
            return db.Books.FirstOrDefault(b => b.GutenbergId == id);
        }
    }
}
