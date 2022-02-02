using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class ShopController : Controller
    {
        BookStoreEntities Context = new BookStoreEntities();
        // GET: Shop
        public ActionResult Index()
        {
            var BookData = Context.Books.ToList();

            return View("Shop", BookData);
        }
        public ActionResult ShopDetails(int? id)
        {
            Book b1 = Context.Books.Where(d => d.ISBN == id).FirstOrDefault();

            return View("details", b1);
        }
        public ActionResult addToCart(int id, int Count)
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("/LogIn");
            }
            var b1 = Context.Books.Where(d => d.ISBN == id).FirstOrDefault();
            bool ifexist = false;
            foreach (AddToCart item in Context.AddToCarts.ToList())
            {
                if (item.ISBN == id)
                {
                    ifexist = true;
                    item.Count += Count;
                    item.Total_Price = item.Count * b1.Price;
                    Context.SaveChanges();
                    break;
                }
            }
            if (!ifexist)
            {
                AddToCart a1 = new AddToCart();
                int cust = (int)Session["CustomerID"];
                var cust1 = Context.Customers.Where(x => x.Customer_ID == cust).FirstOrDefault();
                a1.ISBN = id;
                a1.Customer_ID = cust1.Customer_ID;
                a1.Count = Count;
                a1.Total_Price = Count * b1.Price;
                Context.AddToCarts.Add(a1);
                Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}