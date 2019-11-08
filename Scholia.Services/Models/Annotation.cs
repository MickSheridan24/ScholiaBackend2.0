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


        public void Update(Annotation a) {
            this.Id = a.Id;
            this.BookId = a.BookId;
            this.UserId = a.UserId;
            this.StudyId = a.StudyId;
            this.Title = a.Title;
            this.LocationCharIndex = a.LocationCharIndex;
            this.LocationPIndex = a.LocationPIndex;
            this.Color = a.Color;
            this.IsPublic = a.IsPublic; 
        }

        public Dictionary<string, string> JsonReady() {
            var ret = new Dictionary<string, string>();
            ret["id"] = this.Id.ToString();
            ret["book_id"] = this.BookId.ToString();
            ret["user_id"] = this.UserId.ToString();
            ret["study_id"] = this.StudyId.ToString();
            ret["title"] = this.Title;
            ret["location_p_index"] = this.LocationPIndex.ToString();
            ret["location_char_index"] = this.LocationCharIndex.ToString();
            ret["color"] = this.Color;
            ret["public"] = this.IsPublic.ToString();

            return ret; 
        }

    }
}
