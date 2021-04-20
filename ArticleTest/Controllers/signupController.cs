using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using TransactionLayer;

namespace ArticleTest.Controllers
{
    public class signupController : Controller
    {
        SignupStore ss = new SignupStore();
        // GET: signup
        public ActionResult signup()
        {
            return View();
        }


        public string InsertDetails(SignUpEntity a_details)
        {

            var result = ss.Save_User_Details(a_details);
            if (result < 1)
            {
                return "user Added Successfully";
            }
            else
            {
                return "user Not Saved";
            }
        }
    }
}