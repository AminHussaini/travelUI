﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace travelProject.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult index()
        {
            return View();
        }
        public ActionResult contactUs()
        {
            return View();
        }
    }
}