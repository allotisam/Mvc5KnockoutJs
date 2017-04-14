using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace BootstrapIntro.ViewModels
{
    public class ReturnData
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Content { get; set; }
        public string ReasonPhase { get; set; }


        public ReturnData(HttpStatusCode httpStatusCode, string content, string reasonPhase)
        {
            HttpStatusCode = httpStatusCode;
            Content = content;
            ReasonPhase = reasonPhase;
        }
    }
}