﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TestProject.Controllers
{
    public class BaseController : ApiController
    {
        protected DBAContext objContext;

        public BaseController()
        {
            objContext = new DBAContext();
        }

     }
   }