using Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Xml;

namespace Application.Controllers
{
    public class PostAPIController : ApiController
    {
        public IHttpActionResult GetPostFeedBack_API()
        {
            DBSubmitPost objDB = new DBSubmitPost();
            var jsonResult = (dynamic)null;
            jsonResult = Json(objDB.GetPostFeedBack_API());
            return jsonResult;

        } 
    }
}
