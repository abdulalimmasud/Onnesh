using OnneshProject.DAL;
using OnneshProject.Models;
using OnneshProject.Security;
using OnneshProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnneshProject.Controllers
{
    public class AccountsController : Controller
    {
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Account account)
        {            
            if (ModelState.IsValid)
            {
                Account acc = new Repository().AdminLogin(account);
                SessionPersister.Id = acc.Id;
                SessionPersister.Name = acc.Name;
                SessionPersister.Email = acc.Email;
                SessionPersister.AccountType = acc.AccountType;
                return RedirectToAction("Index", "Admin");
            }
            else 
            {
                ViewBag.Error = "Account's Invalid";
                return View();
            }
        }
        public ActionResult AdminLogout()
        {
            SessionPersister.Id = string.Empty;
            SessionPersister.Name = string.Empty;
            SessionPersister.Email = string.Empty;
            SessionPersister.AccountType = string.Empty;
            return RedirectToAction("Login");
        }
        [AdminAuthorize(Roles = "Super,Admin,Accounts")]
        public ActionResult AddAdmin()
        {
            ViewBag.Districts = DistrictList();
            ViewBag.AdminTypes = AdminTypes();
            return View();
        }
        public List<SelectListItem> DistrictList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem { Value = "", Text = "Select", Selected = true });
            foreach (Districts district in new GeneralGateway().GetDistricts())
            {
                selectList.Add(new SelectListItem { Value = district.Id.ToString(), Text = district.Name });
            }
            return selectList;
        }
        public List<SelectListItem> AdminTypes()
        {
            List<SelectListItem> selectList = new List<SelectListItem>()
            {
                new SelectListItem { Value="",Text="Select",Selected=true},
                new SelectListItem {Value="2",Text="Admin" },
                new SelectListItem {Value="3",Text="Content" },
                new SelectListItem {Value="2",Text="Sales" },
                new SelectListItem {Value="2",Text="Accounts" },
                new SelectListItem {Value="2",Text="CRM" }
            };
            return selectList;
        }
    }
}