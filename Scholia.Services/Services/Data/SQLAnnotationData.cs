using Scholia.Models;
using Scholia.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholia.Models.Interfaces;

namespace Scholia.Services.Data {
    public class SQLAnnotationData : IAnnotationData {

        private ScholiaDbContext db;

        public SQLAnnotationData(ScholiaDbContext db) {
            this.db = db;
        }

        public Annotation Get(int id) {
            return db.Annotations.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Annotation> GetAll() {
            return db.Annotations;
        }

        public void Add(Annotation a) {
            db.Annotations.Add(a);
            db.SaveChanges();
        }

        public void Delete(int id) {
            var ann = db.Annotations.FirstOrDefault(a => id == a.Id);
            db.Annotations.Remove(ann);
        }

        public void Update(Annotation annotation) {
            var ann = db.Annotations.FirstOrDefault(a => annotation.Id == a.Id);
            ann.Update(annotation);
            db.SaveChanges();
        }
    }
}
