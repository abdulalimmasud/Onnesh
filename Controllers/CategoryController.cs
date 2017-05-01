using OnneshProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnneshProject.Controllers
{
    [RoutePrefix("Category")]
    public class CategoryController : ApiController
    {
        [HttpGet, Route(template: "GetCategory")]
        public IHttpActionResult LoadCategory(int categoryType)
        {
            try
            {
                var data = new CategoryGateway().GetCategory(categoryType);
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
        [HttpGet, Route(template: "GetSubCategory")]
        public IHttpActionResult LoadSubCategory(int categoryType, int parentId)
        {
            try
            {
                var data = new CategoryGateway().GetSubCategory(categoryType, parentId);
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
