using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Models;

namespace Scholia.Models.Interfaces {
    public interface IBookFetcher {

        Book Fetch(int id);
        Dictionary<Object,Object> Search(string param);
    }
}
