using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Models
{ 
    public class DBPostFeedback
    {
        OutputResult objResult = new OutputResult();
        //Function objFunction = new Function();

        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da;

        string setSP = "spSet_PostFeedback";
        string getSP = "spGet_PostFeedback";

        #region Save Data
        private enum SaveOption
        {
            SaveRow = 1, UpdateRow = 2
        }
        public OutputResult SavePostFeedback(PostFeedback objItem, string UserBy)
        {
            try
            {
                cmd = new SqlCommand(setSP, DataManager.cnConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SaveOption", SqlDbType.Int).Value = SaveOption.SaveRow;
                cmd.Parameters.Add("@PostFeedbackID", SqlDbType.Int).Value = objItem.PostFeedbackID;
                cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = objItem.PostID;
                cmd.Parameters.Add("@PostComment", SqlDbType.VarChar).Value = objItem.PostComment;
                cmd.Parameters.Add("@PostLike", SqlDbType.Int).Value = objItem.PostLike; 
                cmd.Parameters.Add("@PostDislike", SqlDbType.Int).Value = objItem.PostDislike; 
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = objItem.IsActive;
                cmd.Parameters.Add("@UserBy", SqlDbType.VarChar).Value = UserBy;

                SqlParameter paramIdentityValue = new SqlParameter("@IdentityValue", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, null);
                cmd.Parameters.Add(paramIdentityValue);

                SqlParameter ErrNo = new SqlParameter("@ErrNo", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, null);
                cmd.Parameters.Add(ErrNo);
                DataManager.cnConnection.Open();

                objResult.NoofRows = cmd.ExecuteNonQuery();
                objResult.ErrorNo = int.Parse(cmd.Parameters["@ErrNo"].Value.ToString());
                objResult.ResultId = int.Parse(cmd.Parameters["@IdentityValue"].Value.ToString());

                if (objResult.NoofRows > 0 && objResult.ResultId > 0)
                {
                    objResult.Message = "Save operation successful.";
                }
                else
                {
                    if (objResult.ErrorNo == -1)
                    {
                        objResult.Message = "Save operation failed.";
                    }
                }
            }
            catch (Exception ex)
            {
                objResult.ExceptionError = ex.ToString();
                objResult.ResultId = 0;
                objResult.ErrorNo = -1;
                objResult.Message = "Exception: Save operation failed.";
            }
            finally
            {
                DataManager.cnConnection.Close();
                cmd = null;
            }
            return objResult;
        } 

        #endregion

        #region Load Data

        int LoadPostFeedback = 1,
            LoadPostCount = 2;
        private List<PostFeedback> GetData(int LoadOption, PostFeedback ObjItem, string UserID)
        {
            List<PostFeedback> listData = new List<PostFeedback>();
            try
            {
                cmd = new SqlCommand(getSP, DataManager.cnConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@LoadOption", SqlDbType.Int).Value = LoadOption;
                cmd.Parameters.Add("@PostFeedbackID", SqlDbType.Int).Value = ObjItem.PostFeedbackID;
                cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = ObjItem.PostID;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = ObjItem.IsActive;
                dt = DataManager.ExecuteQuerySqlCommand(cmd);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PostFeedback listItem = new PostFeedback();
                        if (LoadOption == LoadPostFeedback) // 1
                        {
                            listItem.PostFeedbackID = dt.Rows[i]["PostFeedbackID"].ToString();
                            listItem.PostID = dt.Rows[i]["PostID"].ToString();
                            listItem.PostComment = dt.Rows[i]["PostComment"].ToString();
                            listItem.PostLike = dt.Rows[i]["PostLike"].ToString();
                            listItem.PostDislike = dt.Rows[i]["PostDislike"].ToString(); 
                            listItem.IsActive = dt.Rows[i]["IsActive"].ToString();
                            listItem.Status = dt.Rows[i]["Status"].ToString(); 
                        }
                        else if (LoadOption == LoadPostCount) // 2
                        {
                            listItem.PostLike = dt.Rows[i]["PostLike"].ToString();
                            listItem.PostDislike = dt.Rows[i]["PostDislike"].ToString(); 
                        }
                        listData.Add(listItem);
                    }
                }
            }
            catch (Exception ex)
            {
                objResult.ExceptionError = ex.ToString();
            }
            finally
            {
                objResult.IsLogin = "0";
            }
            return listData;
        }
        public List<PostFeedback> GetPostFeedback(string PostFeedbackID, string IsActive, string User) // 1
        {
            List<PostFeedback> listData = new List<PostFeedback>();
            PostFeedback ObjItem = new PostFeedback();

            if (PostFeedbackID == "" || PostFeedbackID == null)
            {
                ObjItem.PostFeedbackID = "-1";
            }
            else
            {
                ObjItem.PostFeedbackID = PostFeedbackID;
            }

            if (IsActive == "" || IsActive == null)
            {
                ObjItem.IsActive = "-1";
            }
            else
            {
                ObjItem.IsActive = IsActive;
            }

            listData = GetData(LoadPostFeedback, ObjItem, User);
            return listData;
        }
        public List<PostFeedback> GetPostCount(string PostID, string IsActive, string User) // 1
        {
            List<PostFeedback> listData = new List<PostFeedback>();
            PostFeedback ObjItem = new PostFeedback();

            if (PostID == "" || PostID == null)
            {
                ObjItem.PostID = "-1";
            }
            else
            {
                ObjItem.PostID = PostID;
            }

            if (IsActive == "" || IsActive == null)
            {
                ObjItem.IsActive = "-1";
            }
            else
            {
                ObjItem.IsActive = IsActive;
            }

            listData = GetData(LoadPostCount, ObjItem, User);
            return listData;
        }
        
        
        #endregion
    }
}