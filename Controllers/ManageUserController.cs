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
        [HttpGet]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult EditUser(int id)
        {
            ViewBag.Districts = new AccountsController().DistrictList();
            Users user = new UserGateway().GetUser(id);
            return View(user);
        }
        [HttpPost]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult EditUser(Users user)
        {
            ViewBag.Districts = new AccountsController().DistrictList();
            if (ModelState.IsValid)
            {
                int rowAffected = new UserGateway().UpdateUser(user);
                if (rowAffected > 0)
                    ViewBag.Success = "Site user info updated successful";
                else
                    ViewBag.Error = "Server temporary unavailable.";
            }
            else
                ViewBag.Error = "Information is missing.";
            return View(user);
        }
        [HttpGet]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult ConfrimUser(int id)
        {
            int confrimBy = Convert.ToInt32(SessionPersister.Id);
            int rowAffected = new UserGateway().ConfirmUser(id, confrimBy);
            if (rowAffected > 0)
                ViewBag.Success = "User Confrim Successful";
            else
                ViewBag.Error = "Server does not response";
            List<Users> users = new UserGateway().GetUsers(0, 1);
            return View("NonConfirmUserList",users);
        }
        [HttpGet]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult DeleteNonConfirmUser(int id)
        {
            int deletedBy = Convert.ToInt32(SessionPersister.Id);
            //int rowAffected = new UserGateway().DeleteUser(id, deletedBy);
            //if (rowAffected > 0)
            //    ViewBag.Success = "User Deleted Successful";
            //else
            //    ViewBag.Error = "Server does not response";
            List<Users> users = new UserGateway().GetUsers(0, 1);
            return View("NonConfirmUserList",users);
        }
    }
}