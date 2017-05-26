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
    public class ManageProviderController : Controller
    {
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult NonCofirmProvider()
        {
            List<ServiceProvider> providers = new ServiceProviderGateway().GetServiceProviders(0, 1);
            return View(providers);
        }
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult Providers()
        {
            List<ServiceProvider> providers = new ServiceProviderGateway().GetServiceProviders(1, 1);
            return View(providers);
        }
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult ConfirmProvider(int id)
        {
            int confirmBy = Convert.ToInt32(SessionPersister.Id);
            new ServiceProviderGateway().ConfirmServiceProvider(id, confirmBy);
            return View("NonCofirmProvider");
        }
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult DeleteNonConfirmProvider(int id)
        {
            int deletedBy = Convert.ToInt32(SessionPersister.Id);
            new ServiceProviderGateway().DeleteServiceProvider(id, deletedBy);
            return View("NonCofirmProvider");
        }
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        [AdminAuthorize(Roles = "Super,Admin")]
        public ActionResult DeleteProvider(int id)
        {
            int deletedBy = Convert.ToInt32(SessionPersister.Id);
            new ServiceProviderGateway().DeleteServiceProvider(id, deletedBy);
            return View("Providers");
        }
    }
}