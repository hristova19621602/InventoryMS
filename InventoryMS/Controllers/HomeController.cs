using InventoryMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryMS.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(User u)
        {
            InventoryDBEntities2 obj = new InventoryDBEntities2();
            var data = obj.st_getLoginDetails(u.u_username, u.u_password);
            foreach (var item in data)
            
            {
                if (item.Username == u.u_username && item.Password == u.u_password)
                {
                    Session["name"] = u.u_username;
                    return RedirectToAction("Contact");
                }
                else { }
            }


            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Session["name"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {

                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("name");
            

            return View("Index");
        }
    }
}