﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Services.Models {
    public class Study {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public bool PublicSubscribe { get; set; }
        public bool PublicContribute { get; set; }

    }
}
