using Scholia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Models.Interfaces {
    public interface IAnnotationData {

        IEnumerable<Annotation> GetAll();
        Annotation Get(int id);
        void Update(Annotation a);
        void Delete(int id);
        void Add(Annotation a);
    }
}
