using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scholia.Services.MockDB;
using Scholia.Services.DB;
using System.Threading.Tasks;
using Scholia.Services;

namespace Scholia.Seed {
    class Program {
        static void Main(string[] args) {

            var db = new ScholiaDbContext();
            var books = new BookSeeder(db);
            books.Seed(new MockBookData()); 
        }

    }
}
