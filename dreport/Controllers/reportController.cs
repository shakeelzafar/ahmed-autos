using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dreport.Models;
using System.Data.Entity;

namespace dreport.Controllers
{
    public class reportController : Controller
    {
        //
        // GET: /report/
        autosEntities ctx = new autosEntities();
        public ActionResult dashboard()
        {
            return View();
        }
        public ActionResult products()
        {
            return View();
        }
        public ActionResult factors()
        {
            return View();
        }

     
       
    }
}
