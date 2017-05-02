using OnneshProject.DAL;
using OnneshProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Web.Http;

namespace OnneshProject.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        [HttpPost,Route(template:"Register")]
        public IHttpActionResult RegisterUser([FromBody] Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }
            var rowAffeted = new UserGateway().SaveUser(user);
            if(rowAffeted == 0)
            {
                return InternalServerError(new ServerException(message: "Server temporarily unavailable"));
            }
            return Ok(rowAffeted);
        }
    }
}
