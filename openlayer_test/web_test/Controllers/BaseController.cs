using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_web.Controllers
{
    public class BaseController : Controller
    {
        public static string PasswordSalt
        {
            get
            {
                return "test";
            }
        }
        
        //
        // GET: /Base/

        public ActionResult Index()
        {
            return View();
        }

    }
}
