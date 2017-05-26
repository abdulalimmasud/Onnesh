using OnneshProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnneshProject.Controllers
{
    public class ServiceProviderController : Controller
    {
        [HttpGet]
        [ProviderAuthorize(Roles = "Provider")]
        public ActionResult Index()
        {
            return View();
        }
    }
}