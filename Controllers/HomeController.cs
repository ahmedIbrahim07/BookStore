using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        BookStoreEntities Context = new BookStoreEntities();
        public ActionResult Index()
        {
            List<Book> newArivals = Context.Books.ToList();
            List<Book> newArivals2 = new List<Book>();
            int iteration = 0;
            foreach (var item in newArivals)
            {
                iteration++;

                if (iteration > newArivals.Count - 3)
                {
                    newArivals2.Add(item);
                }
            }

            var BookData = Context.Books.ToList();
            ViewBag.newArivals = newArivals2;
            return View(BookData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Orders()
        {
            int cutomer_id = (int)Session["CustomerID"];
            var order = Context.Orders.Where(d => d.customer_id == cutomer_id).ToList();
            return View(order);
        }
    }
}