using OnneshProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnneshProject.Controllers
{
    [RoutePrefix("General")]
    public class GeneralController : ApiController
    {
        [HttpGet, Route(template: "Districts")]
        public IHttpActionResult LoadDistricts()
        {
            try
            {
                var data = new GeneralGateway().GetDistricts();
                if (data == null)
                {
                    return InternalServerError(exception: new ApplicationException(message: "Server temporarily unavailable."));
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(exception: ex);
            }
        }
    }
}
