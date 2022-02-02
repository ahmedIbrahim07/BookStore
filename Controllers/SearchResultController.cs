using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class SearchResultController : Controller
    {
        // GET: SearchResult
        BookStoreEntities context = new BookStoreEntities();
        public ActionResult Index(string searchName)
        {
            var book = context.Books.Where(c => c.Title.Contains(searchName)).ToList();
            return View(book);
        }
    }
}