using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using TransactionLayer;

namespace ArticleTest.Controllers
{
    public class ArticleController : Controller
    {

        
        // GET: Article
        ArticleOperations AO = new ArticleOperations();

        public ActionResult ArticleView()
        {
            //Select_Details();
            return View();
        }

        //public ActionResult ArticleViewFront()
        //{
        //    return View();
        //}

        public string InsertDetails(ArticleEntity a_details)
        {

            var result = AO.Save_Details(a_details);
            if (result == 1)
            {
                return "Article Added Successfully";
            }
            else
            {
                return "Article Not Saved";
            }
        }

        public string Update_Details(ArticleEntity a_Details)
        {

            int result = AO.Update_details(a_Details);
            if (result == 1)
            {
                return "Article Updated Successfully";
            }
            else
            {
                return "Article Not Updated";
            }
        }

        public string Delete_Details(ArticleEntity a_Details)
        {

            int result = AO.Delete_details(a_Details);
            if (result == 1)
            {
                return "Delete Updated Successfully";
            }
            else
            {
                return "Delete Not Updated";
            }
        }


        public JsonResult Select_Details()
        {
            var data = AO.Select_Details();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}