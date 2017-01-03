using FurnitureWizardDemo.Models;
using System;
using System.Collections.Generic;
using FurnitureWizardDemo.ViewModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureWizardDemo.Controllers
{
    public class New_PurchaseController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }

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
                return View(displaySelectedOption);
            }
            return HttpNotFound();

        }

    }
}