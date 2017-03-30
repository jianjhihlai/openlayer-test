using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Security;

using test_web.Models;

using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.EF;
using Openlayer_test.TESTDB.Interface;



namespace web_test.Helpers
{
    public class WebSiteHelper
    {
        public static string CurrentUserName
        {

            get
            {

                var httpContext = HttpContext.Current;

                var identity = httpContext.User.Identity as FormsIdentity;



                if (identity == null)
                {

                    return string.Empty;

                }

                else
                {

                    var userID = identity.Name;

                    return SystemUserName(userID);

                }

            }

        }



        /// <summary>

        /// Systems the name of the user.

        /// </summary>

        /// <param name="id">The identifier.</param>

        /// <returns></returns>

        public static string SystemUserName(Object id)
        {

            string userName = string.Empty;



            int systemUserID;



            if (!int.TryParse(id.ToString(), out systemUserID))
            {

                return userName;

            }

            if (systemUserID.Equals(0))
            {

                userName = "系統預設";

            }

            else
            {
                IUserRepository user_model = new Openlayer_test.TESTDB.EF.UserRepository();
                var user = user_model.GetOne(systemUserID);
                if (user.ID > 0)
                {
                    if (user.Name.Equals(""))
                    {
                        userName = "匿名";
                    }
                    else
                    {
                        userName = user.Name;
                    }
                }
                //using (SampleContext db = new SampleContext())
                //{

                //    var user = db.SystemUsers.FirstOrDefault(x => x.ID == systemUserID);

                //    userName = (user == null) ? string.Empty : user.Name;

                //}

            }

            return userName;

        }



    }

}