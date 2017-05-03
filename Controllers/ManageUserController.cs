using OnneshProject.DAL;
using OnneshProject.Models;
using OnneshProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnneshProject.Controllers
{
    public class ManageUserController : Controller
    {
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult NonConfirmUserList()
        {
            List<Users> users = new UserGateway().GetUsers(0, 1);
            return View(users);
        }
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult Users()
        {
            List<Users> users = new UserGateway().GetUsers(1, 1);
            return View(users);
        }
    }
}