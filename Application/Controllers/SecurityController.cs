using Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class SecurityController : Controller
    {
        //#region Start :: Security
        //// GET: Security
        bool isCompleted = true;
        string sMessage = "";
        //SecurityDB objSecurity = new SecurityDB();

        #region Start :: Login Information
        //----------------- Start :: Action -----------------
        public ActionResult Index()
        {
            ALLMENU allMenu = new ALLMENU();
            allMenu = (ALLMENU)Session["Menu"];
            if (allMenu != null)
            {
                ViewBag.MenuTitle = "";
                return RedirectToAction("../Home/Home");
            }
            else
            {
                return View();
            }
        }

        //------------------ End :: Action ------------------

        //---------------- Start :: Function ---------------- 
        [HttpPost]
        public JsonResult GetLogin(string UserID, string Password)
        {
            ALLMENU allMenu = new ALLMENU();
            List<MenuPermission> listData = new List<MenuPermission>();

            SqlCommand cmd = new SqlCommand();
            try
            {
                string strLogin = @"Select * From UserInformation Where UserID = @UserID And Password = @Password AND IsActive = 1";
                cmd = new SqlCommand(strLogin, DataManager.cnConnection);
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Encrypt(Password);
                DataTable dt = DataManager.ExecuteQuerySqlCommand(cmd);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MenuPermission listItem = new MenuPermission();
                        listItem.UserID = dt.Rows[i]["UserID"].ToString();
                        listItem.UserName = dt.Rows[i]["UserName"].ToString();
                        listData.Add(listItem);
                    }

                    allMenu.ListObjMenuPermission = listData;

                    if (allMenu.ListObjMenuPermission != null && allMenu.ListObjMenuPermission.Count != 0)
                    {
                        Session["UserID"] = allMenu.ListObjMenuPermission[0].UserID;
                        Session["UserName"] = allMenu.ListObjMenuPermission[0].UserName;
                        Session["Menu"] = allMenu;
                        return Json(new { isCompleted = true, redirectUrl = Url.Action("Home", "Home") }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        sMessage = "Login Failed, Please try again.";
                    }
                }
                else
                {
                    sMessage = "Login Failed, Please try again.";
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {

            }
            return Json(new { isCompleted = false, redirectUrl = Url.Action("Index", "Security"), sMessage = sMessage }, JsonRequestBehavior.AllowGet);
        }
        public string Encrypt(string cleanString)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            return BitConverter.ToString(hashedBytes);
        }

        //----------------- End :: Function -----------------  
        #endregion End :: Login Information 


         
    }
}