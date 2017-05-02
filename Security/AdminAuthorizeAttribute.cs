using OnneshProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnneshProject.Security
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Email))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Accounts", Action = "AdminLogin" }));
            else
            {
                Repository repository = new Repository();
                CustomPrincipal customPrincipal = new CustomPrincipal(repository.AdminFind(SessionPersister.Email));
                if (!customPrincipal.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Accounts", Action = "AdminLogin" }));
            }
        }
    }
}