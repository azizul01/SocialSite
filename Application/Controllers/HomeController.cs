using Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : Controller
    { 
        #region Start :: Home Information
        //----------------- Start :: Action -----------------
        public ActionResult Home()
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                ViewBag.MenuTitle = "";
                return View();
            }
            else
            {
                return RedirectToAction("../Security/Index");
            }
        }
        //------------------ End :: Action ------------------
        #endregion End :: Home Information


        #region Start :: SubmitPost Information
        //----------------- Start :: Action -----------------
        public ActionResult SubmitPost()
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                ViewBag.MenuTitle = "";
                return View();
            }
            else
            {
                return RedirectToAction("../Security/Index");
            }
        }
        //------------------ End :: Action ------------------

        //------------------ Start :: Function ------------------
        public ActionResult SavePost(PostInformation objItem)
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                DBSubmitPost objDB = new DBSubmitPost();
                return Json(objDB.SavePost(objItem, allMenu.ListObjMenuPermission[0].UserID.ToString()));
            }
            else
            {
                return Json(new { JsonData = "", IsLogin = "1", redirectUrl = Url.Action("Index", "Security") }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UpdatePost(PostInformation objItem)
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                DBSubmitPost objDB = new DBSubmitPost();
                return Json(objDB.UpdatePost(objItem, allMenu.ListObjMenuPermission[0].UserID.ToString()));
            }
            else
            {
                return Json(new { JsonData = "", IsLogin = "1", redirectUrl = Url.Action("Index", "Security") }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetPostInformation(string PostID, string IsAcive)
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                DBSubmitPost objDB = new DBSubmitPost();
                var jsonResult = Json(objDB.GetPostInformation(PostID, IsAcive, allMenu.ListObjMenuPermission[0].UserID.ToString()), JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return Json(new { JsonData = jsonResult, IsLogin = "0" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { JsonData = "", IsLogin = "1", redirectUrl = Url.Action("Index", "Security") }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetPostFeedBack(string PostID, string IsAcive)
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                DBSubmitPost objDB = new DBSubmitPost();
                var jsonResult = Json(objDB.GetPostFeedBack(PostID, IsAcive, allMenu.ListObjMenuPermission[0].UserID.ToString()), JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return Json(new { JsonData = jsonResult, IsLogin = "0" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { JsonData = "", IsLogin = "1", redirectUrl = Url.Action("Index", "Security") }, JsonRequestBehavior.AllowGet);
            }
        }
        public void SavePostImage(HttpPostedFileBase File, string PostID)
        {
            try
            {
                var fileName = Path.GetFileName(File.FileName);
                fileName = PostID + "_" + fileName;

                string rootFolderPath = @"E:\Uploads\PostImage";

                if (!Directory.Exists(rootFolderPath))
                {
                    Directory.CreateDirectory(rootFolderPath);

                }
                string filesToDelete = PostID + "_" + @"*.*";
                string[] fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete);
                foreach (string file in fileList)
                {
                    System.IO.File.Delete(file);
                }

                var path = Path.Combine(@"E:\\Uploads\\PostImage\\", fileName);
                File.SaveAs(path);
            }
            catch
            {

            }
        }
        //------------------ End :: Function ------------------
        #endregion End :: SubmitPost Information

        #region Start :: Post Feed Back Information 
        
        //------------------ Start :: Function ------------------
        public ActionResult SavePostFeedback(PostFeedback objItem)
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                DBPostFeedback objDB = new DBPostFeedback();
                return Json(objDB.SavePostFeedback(objItem, allMenu.ListObjMenuPermission[0].UserID.ToString()));
            }
            else
            {
                return Json(new { JsonData = "", IsLogin = "1", redirectUrl = Url.Action("Index", "Security") }, JsonRequestBehavior.AllowGet);
            }
        } 
        public JsonResult GetPostCount(string PostID, string IsAcive)
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                DBPostFeedback objDB = new DBPostFeedback();
                var jsonResult = Json(objDB.GetPostCount(PostID, IsAcive, allMenu.ListObjMenuPermission[0].UserID.ToString()), JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return Json(new { JsonData = jsonResult, IsLogin = "0" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { JsonData = "", IsLogin = "1", redirectUrl = Url.Action("Index", "Security") }, JsonRequestBehavior.AllowGet);
            }
        }
        //------------------ End :: Function ------------------
        #endregion End :: Post Feed Back Information


        #region Start :: Post Feed Back Information
        //------------------- Start :: Action ------------------
        public ActionResult WebAPI_POST()
        {
            return View();
        }
        //-------------------- End :: Action -------------------
        //------------------ Start :: Function -----------------
        public JsonResult GetPostFeedBack_API()
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                DBSubmitPost objDB = new DBSubmitPost();
                var jsonResult = Json(objDB.GetPostFeedBack_API(), JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return Json(new { JsonData = jsonResult, IsLogin = "0" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { JsonData = "", IsLogin = "1", redirectUrl = Url.Action("Index", "Security") }, JsonRequestBehavior.AllowGet);
            }
        }
        //------------------- End :: Function ------------------
        #endregion End :: Post Feed Back Information 


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}