﻿using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responce;

namespace SIS.WebServer.Results
{
    public class RedirectResult:ActionResult
    {
        public RedirectResult(string location)
        :base(HttpResponseStatusCode.SeeOther)
        {
            Headers.AddHeader(new HttpHeader("Location",location));
        }
    }
}