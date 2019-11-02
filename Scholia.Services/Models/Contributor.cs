using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Services.Models {
    public class Contributor {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StudyId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
