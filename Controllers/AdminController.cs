using OnneshProject.DAL;
using OnneshProject.Models;
using OnneshProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnneshProject.Controllers
{
    public class AdminController : Controller
    {
        [AdminAuthorize(Roles = "Super,Admin,Content,Sales,Accounts,CRM")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AdminAuthorize(Roles = "Super,Content,Sales,CRM")]
        public ActionResult AddCategory()
        {
            ViewBag.CategoryType = CategoryType();
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category categroy)
        {
            ViewBag.CategoryType = CategoryType();
            if (ModelState.IsValid)
            {
                int rowAffected = new CategoryGateway().SaveCategory(categroy);
                if (rowAffected > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Sub Category Added Successful.";
                }
                else
                {
                    ViewBag.Error = "Sorry! Something get error!";
                }
            }
            return View();
        }
        [HttpGet]
        [AdminAuthorize(Roles = "Super,Content,Sales,CRM")]
        public ActionResult AddSubCategory()
        {
            ViewBag.CategoryType = CategoryType();
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCategory(Category categroy)
        {
            ViewBag.CategoryType = CategoryType();
            if (ModelState.IsValid)
            {
                int rowAffected = new CategoryGateway().SaveSubCategory(categroy);
                if (rowAffected > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Sub Sub Category Added Successful.";
                }
                else
                {
                    ViewBag.Error = "Sorry! Something get error!";
                }
            }
            return View();
        }
        public List<SelectListItem> CategoryType()
        {
            List<SelectListItem> selectList = new List<SelectListItem>()
            {
                new SelectListItem {Value="",Text="Select",Selected=true },
                new SelectListItem {Value="1",Text="Education" },
                new SelectListItem {Value="2",Text="Training" }
            };
            return selectList;
        }
        public JsonResult CategoryList(int categoryType)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (Category category in new CategoryGateway().GetCategory(categoryType))
            {
                selectList.Add(new SelectListItem { Value = category.Id.ToString(), Text = category.Name });
            }
            return Json(new SelectList(selectList, "Value", "Text"));
        }
    }
}