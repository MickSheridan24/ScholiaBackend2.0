using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Models {
    public class Annotation {
        public int Id { get; set; }

        public int BookId { get; set; }
        public int UserId { get; set; }
        public int StudyId { get; set; }
        public string Title { get; set; }
        public int LocationPIndex { get; set; }
        public int LocationCharIndex { get; set; }
        public string Color { get; set; }
        public bool IsPublic { get; set; }


    }
}
