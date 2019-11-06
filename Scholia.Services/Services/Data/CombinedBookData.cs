using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Models;
using Scholia.Models.Interfaces;

namespace Scholia.Services.Data {
    public class CombinedBookData : IBookFetcher {

        private IBookData sql;
        private IBookFetcher api;

        public CombinedBookData(IBookData sql, IBookFetcher api) {
            this.sql = sql;
            this.api = api;
        }


        public Book Fetch(int id) {

            var book = sql.Fetch(id);
            if (book != null) {
                return book;
            }else {
                book = api.Fetch(id);
                if (book != null) {
                    return book; 
                }
            }
            
            return null;
        }


        public Dictionary<Object, Object> Search(string query) {
           return api.Search(query);
        }
    }
}
