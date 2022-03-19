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
        private object u_roleID;

        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(User u)
        {
            InventoryDBEntities2 obj = new InventoryDBEntities2();
            var data = obj.st_getLoginDetails(u.u_username, u.u_password, u.u_roleID);
            foreach (var item in data)
            
            {
                if (u.u_status == 0)
                {
                    if (item.Username == u.u_username && item.Password == u.u_password)
                    {
                        Session["name"] = u.u_username;
                        return RedirectToAction("Contact");
                    }
                    else { }
                }
                else if (u.u_status == 1){
                    if (item.Username == u.u_username && item.Password == u.u_password)
                    {
                        Session["name"] = u.u_username;
                        return RedirectToAction("ContactUser");
                    }
                    else { }
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ContactUser()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("name");
            

            return View("Index");
        }
    }
}