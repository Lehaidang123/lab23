using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string Hellotecher(string univer)
        {
            return "Le Hai Dang - univer" + univer;
        }
        public ActionResult Listbook()
        {
            var books = new List<string>();
            books.Add("Html5 css  complete msnura-author name book1");
            books.Add("Html5 css  complete msnura-author name book2");
            books.Add("Html5 css  complete msnura-author name book1");
            ViewBag.Books = books;

            return View();
        }
        public ActionResult ListbookModel1()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "html5 & css cmplerewew", "Author name Book1", "/Content/images/download (1).png"));
            books.Add(new Book(2, "html5 & css cmplerewew", "Author name Book2", "/Content/images/download (1).png"));
            books.Add(new Book(3, "html5 & css cmplerewew", "Author name Book3", "/Content/images/download (1).png"));

            return View(books);
        }
        public ActionResult Editbook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "html5 & css cmplerewew", "Author name Book1", "/Content/images/download (1).png"));
            books.Add(new Book(2, "html5 & css cmplerewew", "Author name Book2", "/Content/images/download (1).png"));
            books.Add(new Book(3, "html5 & css cmplerewew", "Author name Book3", "/Content/images/download (1).png"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }


            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editbook(int id, string Tilte, string Author, string Image)

        {

            var books = new List<Book>();
            books.Add(new Book(1, "html5 & css cmplerewew", "Author name Book1", "/Content/images/download (1).png"));
            books.Add(new Book(2, "html5 & css cmplerewew", "Author name Book2", "/Content/images/download (1).png"));
            books.Add(new Book(3, "html5 & css cmplerewew", "Author name Book3", "/Content/images/download (1).png"));
            Book book = new Book();
            if (id == null)
            {

                return HttpNotFound();
            }

            foreach (Book b in books)
            {
                if (b.Id == id)
                {

                    b.Tilte = Tilte;
                    b.Author = Author;
                    b.Image = Image;
                    break;
                }
            }



            return View("ListbookModel1", books);
        }

      
        public ActionResult CreateBooks()
        {
            return View();
        }


        [HttpPost,ActionName("CreateBooks")]
            [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "id,tilte,author,image")] Book book)
        {

            var books = new List<Book>();
            books.Add(new Book(1, "html5 & css cmplerewew", "Author name Book1", "/Content/images/download (1).png"));
            books.Add(new Book(2, "html5 & css cmplerewew", "Author name Book2", "/Content/images/download (1).png"));
            books.Add(new Book(3, "html5 & css cmplerewew", "Author name Book3", "/Content/images/download (1).png"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "error");
            }
            return View("ListbookModel1", books);
        }
    }
   
}