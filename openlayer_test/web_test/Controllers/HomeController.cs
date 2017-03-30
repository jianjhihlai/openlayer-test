using System;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using test_web.Models;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.EF;
using Openlayer_test.TESTDB.Interface;

namespace test_web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        IUserRepository _user_model;

        public HomeController()
            : base()
        {
            _user_model = new Openlayer_test.TESTDB.EF.UserRepository();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginViewModel logonModel)
        {

            if (!ModelState.IsValid)
            {

                return View();

            }



            var systemuser = _user_model.QueryOne(logonModel.Account);



            if (systemuser == null)
            {

                ModelState.AddModelError("", "請輸入正確的帳號或密碼!");

                return View();

            }



            var password = BaseController.CryptographyPassword(logonModel.Password, BaseController.PasswordSalt);



            if (systemuser.Password.Equals(password))
            {

                this.LoginProcess(systemuser, logonModel.Remember);

                return RedirectToAction("Index", "Home");

            }

            else
            {

                ModelState.AddModelError("", "請輸入正確的帳號或密碼!");

                return View();

            }

        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();



            //清除所有的 session

            Session.RemoveAll();



            //建立一個同名的 Cookie 來覆蓋原本的 Cookie

            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");

            cookie1.Expires = DateTime.Now.AddYears(-1);

            Response.Cookies.Add(cookie1);



            //建立 ASP.NET 的 Session Cookie 同樣是為了覆蓋

            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");

            cookie2.Expires = DateTime.Now.AddYears(-1);

            Response.Cookies.Add(cookie2);



            return RedirectToAction("Index", "Home");

        }

        

        private void LoginProcess(Openlayer_test.TESTDB.User user, bool isRemeber)
        {

            var now = DateTime.Now;

            //string roles = string.Join(",", user.SystemRoles.Select(x => x.Name).ToArray());



            var ticket = new FormsAuthenticationTicket(

                version: 1,

                name: user.ID.ToString(),

                issueDate: now,

                expiration: now.AddMinutes(30),

                isPersistent: isRemeber,

                userData: "",

                cookiePath: FormsAuthentication.FormsCookiePath);



            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            Response.Cookies.Add(cookie);

        }
    }
}
