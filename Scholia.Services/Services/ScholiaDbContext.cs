using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Services.Models;
using Scholia.Services.MockDB;
using System.Data.Entity;

namespace Scholia.Services {
    public class ScholiaDbContext : DbContext {

        public DbSet<Book> Books { get; set; }


    }
}
