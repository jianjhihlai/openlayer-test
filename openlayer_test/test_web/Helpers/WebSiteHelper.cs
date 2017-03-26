using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Security;

using test_web.Models;



namespace test_web.Helpers
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



            Guid systemUserID;



            if (!Guid.TryParse(id.ToString(), out systemUserID))
            {

                return userName;

            }

            if (systemUserID.Equals(Guid.Empty))
            {

                userName = "系統預設";

            }

            else
            {

                using (SampleContext db = new SampleContext())
                {

                    var user = db.SystemUsers.FirstOrDefault(x => x.ID == systemUserID);

                    userName = (user == null) ? string.Empty : user.Name;

                }

            }

            return userName;

        }



    }

}