using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class DSSocialSite
    {
    }
    public class PostInformation
    {
        public string PostID { get; set; }
        public string PostHead { get; set; }
        public string PostImage { get; set; }
        public string PostImageBase64Bytes { get; set; }
        public string IsActive { get; set; }
        public string Status { get; set; }
        public string PostCreatedBy { get; set; }
        public string PostCreatedUserName { get; set; }
        public string PostCreatedDate { get; set; }
        public string PostUpdatedBy { get; set; } 
        public string PostUpdatedUserName { get; set; }
        public string PostUpdatedDate { get; set; }  
        public string PostFeedbackID { get; set; }
        public string PostComment { get; set; }
        public string PostLike { get; set; }
        public string PostDislike { get; set; }
        public string PostFeedbackCreatedBy { get; set; }
        public string PostFeedbackCreatedUserName { get; set; }
        public string PostFeedbackCreatedDate { get; set; } 
        public string PostFeedbackUpdatedBy { get; set; } 
        public string PostFeedbackUpdatedUserName { get; set; }
        public string PostFeedbackUpdatedDate { get; set; } 
    }
    public class UserInformation
    {

        public string UserInformationID { get; set; }
        
        public string UserID { get; set; }
        
        public string UserName { get; set; }
       
        public string UserEmail { get; set; }
       
        public string Password { get; set; }
      
        public string IsActive { get; set; }
       
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UserExpireDate { get; set; }
    }
    public class PostFeedback
    { 
        public string PostFeedbackID { get; set; } 
        public string PostID { get; set; }
        public string PostComment { get; set; }
        public string PostLike { get; set; }
        public string PostDislike { get; set; } 
        public string IsActive { get; set; }
        public string Status { get; set; } 
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}