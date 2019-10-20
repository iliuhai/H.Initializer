using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace H.Initializer
{
    public class InitMiddlewareOptions
    {
        public InitMiddlewareOptions(string initUrl, string CallbackUrl)
        {
            this.InitUrl = initUrl;
            this.CallbackUrl = CallbackUrl;
        }

        public string InitUrl { get; set; }

        public string CallbackUrl { get; set; }
    }
}
