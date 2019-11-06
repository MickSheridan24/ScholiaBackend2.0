using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Scholia.Models {
    public class Book {


        [Display(Name = "id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "author")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "gutenberg_id")]
        public int GutenbergId { get; set; }
        [Required]
        [Display(Name = "temporary_text")]
        public string Body { get; set; }

    }
}
