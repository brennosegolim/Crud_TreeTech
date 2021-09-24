using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Crud_TreeTech_Web2.Request
{
    public class Base
    {
        public string getAPIUrl()
        {
            string url = string.Empty;
            
            url = ConfigurationManager.AppSettings["ApiUrl"];

            return url;
        }
    }
}