using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        BookStoreEntities Context = new BookStoreEntities();
        public ActionResult Index()
        {
            int customer_id = (int)Session["CustomerID"];
            var add1 = Context.AddToCarts.Where(d => d.Customer_ID == customer_id).ToList();
            if (add1.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }
            return View(add1);
        }
        public ActionResult Confirmation(string Adress)
        {
            int customer_id = (int)Session["CustomerID"];
            var add1 = Context.AddToCarts.Where(d => d.Customer_ID == customer_id).ToList();
            Context.Customers.Where(d => d.Customer_ID == customer_id).FirstOrDefault().Adress = Adress;
            Order o1 = new Order();
            foreach (AddToCart item in add1)
            {
                o1.ISBN = item.ISBN;
                o1.customer_id = item.Customer_ID;
                o1.Adress = Adress;
                o1.Total = item.Total_Price;
                o1.Date = System.DateTime.Now;
                o1.Count = item.Count;
                Context.Orders.Add(o1);
                Context.Books.Where(d => d.ISBN == item.ISBN).FirstOrDefault().Stock -= item.Count;
                Context.AddToCarts.Remove(item);
                Context.SaveChanges();
            }
            return View(o1);
        }
    }
}