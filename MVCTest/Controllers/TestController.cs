using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCTest.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test1()
        {

            ViewBag.ContextID = "Test1";
            var vm = new Test1VM();

            vm.FavoriteColor = new SelectListVM
            {
                SelectedID = "Blue",
                Items = new List<SelectListItem>
                {
                    new SelectListItem{Value="Blue",Text="Blue"},
                    new SelectListItem{Value="Red",Text="Red"},
                    new SelectListItem{Value="Green",Text="Green"},
                }
            };

            return View("Test",vm);
        }

        public ActionResult Test2()
        {
            ViewBag.ContextID = "Test2";
            var vm = new Test2VM();

            return View("Test", vm);
        }

        [HttpPost]
        public ActionResult Test(string contextID,object vm)
        {
            if (ModelState.IsValid)
            {
                return this.RedirectToAction("Index");

            }
            else
            {
                ViewBag.ContextID = contextID;

        


                return View("Test", vm);
            }

        }

    }

    public class ControllerVM
    {
        [Required]
        public string ContextID {get;set;}
        public dynamic ViewModel { get; set; }
    }

}
