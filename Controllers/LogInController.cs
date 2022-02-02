using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        BookStoreEntities Context = new BookStoreEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OpenRegister()
        {
            return View();
        }
        public ActionResult SaveRegister(UseModel objUserModel)
        {
            Customer Cust = new Customer();
            Cust.Email = objUserModel.Email;
            Cust.Name = objUserModel.Name;
            Cust.Password = objUserModel.Password;
            Cust.Phone = objUserModel.Phone;
            Cust.Adress = objUserModel.Adress;
            Context.Customers.Add(Cust);
            Context.SaveChanges();
            Session["CustomerID"] = Cust.Customer_ID;
            Session["userName"] = Cust.Name;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Authorise(UseModel user)
        {
            var userDetail = Context.Customers.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            var isValid = Context.Customers.Where(e => e.Email == user.Email && e.Password == e.Password).FirstOrDefault();
            if (userDetail == null)
            {
             
            
                return View("Index");
            }
            else
            {
                Session["CustomerID"] = userDetail.Customer_ID;
                Session["userName"] = userDetail.Name;
                
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult LogOut()
        {
            //int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}