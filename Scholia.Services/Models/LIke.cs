using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Models {
    public class Like {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnnotationId { get; set; }

    }
}
