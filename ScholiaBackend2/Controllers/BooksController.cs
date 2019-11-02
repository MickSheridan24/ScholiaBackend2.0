using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Scholia.Services.Models;
using ScholiaBackend2.Models;
using Newtonsoft.Json;
using Scholia.Services;
using Scholia.Services.GutenbergService;

namespace ScholiaBackend2.Controllers
{
    public class BooksController : ApiController
    {
        private IBookData db;
        public  BooksController(IBookData db) {
            this.db = db;
        }



        // GET: api/Books
        public IHttpActionResult GetBooks()
        {
            //var books = db.GetAll();

            //return Json(books); 
            var gut = new GutenbergClient();
            return Json(gut.GutenGet());

        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            return Json(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

   //         db.Entry(book).State = EntityState.Modified;

            try
            {
    //            db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

    //        db.Books.Add(book);
     //       db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
           Book book = db.Get(id);
            if (book == null)
            {
                return NotFound();
            }

     //       db.Books.Remove(book);
     //       db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
    //            db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return true;//db.Books.Count(e => e.id == id) > 0;
        }
    }
}