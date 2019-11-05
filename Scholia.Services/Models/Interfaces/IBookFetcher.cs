using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Models;

namespace Scholia.Models.Interfaces {
    public interface IBookFetcher {

        Book Get(int id);
    }
}
