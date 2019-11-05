﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Models {
    public class Book {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int GutenbergId { get; set; }
        public string Body { get; set; }

    }
}
