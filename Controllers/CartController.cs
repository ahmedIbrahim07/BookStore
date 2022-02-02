using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        BookStoreEntities Context = new BookStoreEntities();
        public ActionResult Index()
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("/LogIn");
            }
            int customer_id = (int)Session["CustomerID"];
            var add1 = Context.AddToCarts.Where(d => d.Customer_ID == customer_id).ToList();

            return View(add1);
        }
        public ActionResult RemoveItem(int id)
        {
            AddToCart add1 = Context.AddToCarts.Where(d => d.ISBN == id).FirstOrDefault();

            Context.AddToCarts.Remove(add1);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}