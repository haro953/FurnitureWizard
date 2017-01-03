using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FurnitureWizardDemo.ViewModel;
using System.Web.Mvc;
using FurnitureWizardDemo.Models;

namespace FurnitureWizardDemo.Controllers
{
    public class MainMenuController : Controller
    {
        // GET: MainMenu

       //the defualt action of this controller creates the menu for users to select from
        public ActionResult MainMenu()
        {
            //sets option equal to a list of menu items
            var option = new List<MainMenu>
            {
                new MainMenu {Option = "Inventory" },
                new MainMenu {Option = "New_Purchase" },
                new MainMenu {Option = "Reports" },
                new MainMenu {Option = "Packages" },
                new MainMenu {Option = "Services" },
                new MainMenu {Option = "Customer" }
            };

            //sets the view model equal to the the list of mainmenu items stored inside of the 
            //Main menu model that is passed into the viewModel MainMenuList
            var viewModel = new MainMenuList
            {
                //sets MainMenu equal to what is inside option for data passing purposses
                // due to using abstracted ViewModels for cleaner code
                MainMenu = option
            };

            //returns the list of mainmenu items
            return View(viewModel);
        }


        //method that takes a string parameter and then calls a controller and start method based on the input
        public ActionResult SelectMenuOption(string menuOption)
        {
            //sanity check
            if (menuOption == menuOption && menuOption != null) 
            {
                //calls the method of SelectMenuOption in the dynamicly selected controller and sets the dynamic text to a passable variable
                //this variable is then passed to the dynamic controller ie:ServicesController
                return RedirectToAction("SelectedMenuOption", menuOption, new { selectedOption = menuOption }); 
            }

            //return not found menuitem not found should never get here
            return HttpNotFound(); 
        }

    }
}