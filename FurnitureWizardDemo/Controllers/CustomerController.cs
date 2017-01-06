using FurnitureWizardDemo.Models;
using System;
using System.Collections.Generic;
using FurnitureWizardDemo.ViewModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace FurnitureWizardDemo.Controllers
{
    public class CustomerController : Controller
    {


        //create the local database
        protected CustomerDBContext customerDatabase = new CustomerDBContext();
        
        // calls the showall view to show every customer in the database currently
        //takes a search string to narrow all customers to a specific individual
        public ActionResult ShowAll(string searchString)
        {
            var specificCustomer = from customer in customerDatabase.Customer
                                   select customer;

            if (!String.IsNullOrEmpty(searchString))
            {
                specificCustomer = specificCustomer.Where(s => s.FirstName.Contains(searchString));
            }
            return View(specificCustomer);
            //return View(customerDatabase.Customer.ToList());
        }


        //make sure this is finished with implementation
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = customerDatabase.Customer.Find(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        //calls the create view to create a new customer in the database
        public ActionResult Create()
        {
            return View();
        }


        //creates the customer and binds data to it that will be returned and displayed in the view when showall is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID , FirstName, LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerDatabase.Customer.Add(customer);
                customerDatabase.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            return View(customer);
        }


        //make sure to finish implementation
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = customerDatabase.Customer.Find(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        //make sure to finish implementation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID , FirstName, LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerDatabase.Entry(customer).State = EntityState.Modified;
                customerDatabase.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            return View(customer);

        }


        //make sure to finish implementation
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = customerDatabase.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        //make sure to finish implementation
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = customerDatabase.Customer.Find(id);
            customerDatabase.Customer.Remove(customer);
            customerDatabase.SaveChanges();
            return RedirectToAction("ShowAll");

        }

        //removes customer permenatley from customer database
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                customerDatabase.Dispose();
            }
            base.Dispose(disposing);
        }


        //defualt action of controller
        //calls the view for SelectedMenuOption 
        //takes data passed from MainMenuController SelectMenuOption method
        public ActionResult SelectedMenuOption(string selectedOption)
        {
            //Sanity Check
            if (selectedOption == selectedOption && selectedOption != null)
            {
                //sets selectedOption equal to what is passed into the method
                var displaySelectedOption = new MainMenu() { Option = selectedOption };

                //ultimately returns what was passed in 
                return RedirectToAction("ShowAll"); 
                //return View(displaySelectedOption);
            }
            return HttpNotFound();

        }

        public ActionResult MainMenuReturn()
        {
            //returns the method from a contoller in that order
            return RedirectToAction("MainMenu","MainMenu");
        }

    }
}