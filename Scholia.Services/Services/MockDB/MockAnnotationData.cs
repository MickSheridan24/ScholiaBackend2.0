using Scholia.Models;
using Scholia.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Services.MockDB {
    public class MockAnnotationData : IAnnotationData {

        public List<Annotation> Annotations { get; set; }


        public MockAnnotationData() {
            Annotations = new List<Annotation>() {
                new Annotation{BookId = 6, UserId =1, StudyId=1, Title="This", LocationCharIndex=1, LocationPIndex =1, Color="green", IsPublic=true },
                new Annotation{BookId = 6, UserId =1, StudyId=1, Title="Test2", LocationCharIndex=1, LocationPIndex =1, Color="green", IsPublic=true },
                new Annotation{BookId = 6, UserId =1, StudyId=1, Title="Test3", LocationCharIndex=1, LocationPIndex =1, Color="green", IsPublic=true },
                new Annotation{BookId = 6, UserId =1, StudyId=1, Title="Test4", LocationCharIndex=1, LocationPIndex =1, Color="green", IsPublic=true }

            };

        }

        public void Add(Annotation a) {
            Annotations.Add(a);
        }

        public void Delete(int id) {
            var ann = Annotations.FirstOrDefault(a => a.Id == id);
            Annotations.Remove(ann);
        }

        public Annotation Get(int id) {
            return Annotations.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Annotation> GetAll() {
            return Annotations;
        }

        public void Update(Annotation annotation) {
            var ann = Annotations.FirstOrDefault(a => a.Id == annotation.Id);
            ann.Update(annotation);
        }
    }
}
