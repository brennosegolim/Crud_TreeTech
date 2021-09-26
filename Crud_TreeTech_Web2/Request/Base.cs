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
            return ConfigurationManager.AppSettings["ApiUrl"];
        }

        public string getEmailEnvioAlerta()
        {
            return ConfigurationManager.AppSettings["EmailDestinatarioAlerta"];
        }

        public string getRemetenteEmail()
        {
            return ConfigurationManager.AppSettings["EmailRemetenteAlerta"];
        }

        public string getSenhaRemetenteEmail()
        {
            return ConfigurationManager.AppSettings["SenhaRemetenteAlerta"];
        }
    }
}