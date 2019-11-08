using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Scholia.Models;
using Scholia.Models.Interfaces;
using Scholia.Services;

namespace ScholiaBackend2.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AnnotationsController : ApiController
    {
        private IAnnotationData db;

     
        public AnnotationsController(IAnnotationData db) {
            this.db = db;
       
        }


        // GET: api/Annotations
        public IHttpActionResult GetAnnotations()
        {

            var annotations = db.GetAll().Select(a => a.JsonReady());
                             
            return Json(annotations);
        }

        // GET: api/Annotations/5
        [ResponseType(typeof(Annotation))]
        public IHttpActionResult GetAnnotation(int id)
        {
            var annotation = db.Get(id);
            if (annotation == null)
            {
                return NotFound();
            }

            return Json(annotation.JsonReady());
        }

        // PUT: api/Annotations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnnotation(int id, Annotation annotation)
        {
            db.Update(annotation);
            return Json(annotation.JsonReady());
        }

        // POST: api/Annotations
        [ResponseType(typeof(Annotation))]
        public IHttpActionResult PostAnnotation(Annotation annotation)
        {
            db.Add(annotation);
            return Json(annotation.JsonReady());
        }

        // DELETE: api/Annotations/5
        [ResponseType(typeof(Annotation))]
        public IHttpActionResult DeleteAnnotation(int id)
        {
            db.Delete(id);
            return Json(id);
        }

    }
}