using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodNStuff.MVC.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(_db.Customers.ToList());
        }
        //this takes you to the page.
        //Get Customer/Create
        public ActionResult Create()
        {
            return View(); 
        }
        //Post Customer/Create 
        [HttpPost] //This states that this is the post method 
        [ValidateAntiForgeryToken] 
        public ActionResult Create(Customer customer) //can also be seen as model. 
        {
            if (ModelState.IsValid) //check to see if the model is valid. All the req sections are filled in. 
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return RedirectToAction("Index"); //once the changes are saved this is where it will send you. 
            }
            return View(customer); //what happens if you oont enter the correct information. gives back jank form. 
        }
    }
}