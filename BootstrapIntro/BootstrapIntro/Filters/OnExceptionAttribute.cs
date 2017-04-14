using BootstrapIntro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BootstrapIntro.Filters
{
    public class OnExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exceptionType = filterContext.Exception.GetType().Name;
            ReturnData returnData;

            switch (exceptionType)
            {
                case "ObjectNotFoundException":
                    returnData = new ReturnData(HttpStatusCode.NotFound, filterContext.Exception.Message, "Error");
                    break;
                default:
                    returnData = new ReturnData(HttpStatusCode.InternalServerError, "An error occured. Please try again or contact the admin.", "Error");
                    break;
            }

            filterContext.Controller.ViewData.Model = returnData.Content;
            filterContext.HttpContext.Response.StatusCode = (int)returnData.HttpStatusCode;
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = filterContext.Controller.ViewData
            };
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }
}