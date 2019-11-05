using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Scholia.Models;
using Scholia.Models.Interfaces;


namespace ScholiaBackend2.Controllers {
    public class BooksController : ApiController
    {
        private IBookData db;
        private IBookFetcher service;
        public  BooksController(IBookData db, IBookFetcher service) {
            this.db = db;
            this.service = service;
        }



        // GET: api/Books
        public IHttpActionResult GetBooks()
        {
            var books = db.GetAll();

            return Json(books); 
 

        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        
       
            
            
            
            
            
            
            
            {
            Book book = service.Get(id);
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