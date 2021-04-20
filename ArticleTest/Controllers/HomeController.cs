using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using TransactionLayer;

namespace ArticleTest.Controllers
{
    public class HomeController : Controller
    {
        SignupStore ss = new SignupStore();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult signup()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(SignUpEntity loginModel)
        {
            List<SignUpEntity> listOfUserDetails = new List<SignUpEntity>();
            listOfUserDetails = ss.GetUserLogin(loginModel);
            if (listOfUserDetails.Count > 0)
            {
                Session["email"] = listOfUserDetails[0].email;
                // Session["UserName"] = listOfUserDetails[0].username;

                return RedirectToAction("ArticleView", "Article");
                //  return RedirectToAction("~/Article/ArticleView");
            }
            else
            {
                //  TempData["successmsg"] = "UserId or Password is Incorrect.";
                return RedirectToAction("Index", "Home");
            }
        }

        //public string login(SignUpEntity loginModel)
        //{

        //    List<SignUpEntity> listOfUserDetails = new List<SignUpEntity>();
        //    listOfUserDetails = ss.GetUserLogin(loginModel);
        // //   var result = Convert.ToInt32(listOfUserDetails);

        //    if (listOfUserDetails == "1")
        //    {
        //        return "Article Added Successfully";
        //    }
        //    else
        //    {
        //        return "Article Not Saved";
        //    }
        //}

        //public JsonResult login(SignUpEntity loginModel)
        //{

        //    List<SignUpEntity> listOfUserDetails = new List<SignUpEntity>();
        //    listOfUserDetails = ss.GetUserLogin(loginModel);
        //    return Json
        //    (
        //       new
        //       {
        //           Data = listOfUserDetails,
        //           JsonRequestBehavior = JsonRequestBehavior.AllowGet,
        //           redirectUrl = @Url.Action("ArticleView", "Article")
        //       }
        //    );

        //}



        public string InsertDetails(SignUpEntity a_details)
        {

            var result = ss.Save_User_Details(a_details);
            if (result == 1)
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