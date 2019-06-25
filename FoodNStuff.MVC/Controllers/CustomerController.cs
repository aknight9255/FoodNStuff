using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            return View(_db.Customers.ToList());//displays items in this database on the page which is formated in view 
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

        //GET: Customer/edit/{id}
        public ActionResult Edit (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _db.Customers.Find(id);
            if(customer ==null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        //Post: Customer/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}