using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Scholia.Models {
    public class Book {


        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int GutenbergId { get; set; }
        [Required]
        public string Body { get; set; }

        public Dictionary<string, string> JsonReady() {
            var ret = new Dictionary<string, string>();
            ret["id"] = this.Id.ToString();
            ret["title"] = this.Title;
            ret["author"] = this.Author;
            ret["gutenberg_id"] = this.GutenbergId.ToString();
            ret["body"] = this.Body;
            return ret;
        }
    }
}
