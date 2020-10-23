using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class DSSecurity
    {
    } 
    [Serializable]
    public class ALLMENU
    {
        public List<MenuPermission> ListObjMenuPermission { get; set; }
    } 

    [Serializable]
    public class MenuPermission
    {
        public string Menu_ID { get; set; }
        public string Application_ID { get; set; }
        public string View_Name { get; set; }
        public string Controller { get; set; }
        public string Menu_Head { get; set; }
        public string Menu_URL { get; set; }
        public string Priority { get; set; }
        public string Parent_Menu_ID { get; set; }
        public string UserID { get; set; } 
        public string UserName { get; set; }
        public string Permission_Status { get; set; }
    } 

    [Serializable]
    public class User_Information
    {
        public string User_Information_ID { get; set; }
        public string User_ID { get; set; }
        public string Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string User_Status { get; set; }
        public string Create_By { get; set; }
        public int Create_Date_Time { get; set; }
        public int Is_Not_Found { get; set; }
        public int CommandID { get; set; }
        public int Result { get; set; }
    }
    public class OutputResult
    {
        public int ResultId { get; set; }
        public string Message { get; set; }
        public string ExceptionError { get; set; }
        public int ErrorNo { get; set; }
        public string ReturnValue { get; set; }
        public int NoofRows { get; set; }
        public string IsLogin { get; set; }
    }
}