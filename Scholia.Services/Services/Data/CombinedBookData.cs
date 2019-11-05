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


        public Book Get(int id) {

            var book = sql.Get(id);
            if (book != null) {
                return book;
            }else {
                book = api.Get(id);
                if (book != null) {
                    return book; 
                }
            }
            
            return null;
        }
    }
}
